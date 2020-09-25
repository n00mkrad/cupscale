using Cupscale.Cupscale;
using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.OS
{
	internal class ESRGAN
	{
		private static Process currentProcess;

		public enum PreviewMode { None, Cutout, FullImage }
		

		public static async Task UpscaleBasic(string inpath, string outpath, ModelData mdl, string tilesize, bool alpha, PreviewMode mode, bool allowNcnn, bool showTileProgress = true)
		{
            try
            {
                if (allowNcnn && Config.GetBool("useNcnn"))
                {
					Program.mainForm.SetProgress(1f, "Loading ESRGAN-NCNN...");
					DialogForm dialogForm = new DialogForm("Loading ESRGAN-NCNN...\nThis should take 10-20 seconds.", 10);
					Program.lastModelName = mdl.model1Name;
					await RunNcnn(inpath, outpath, mdl.model1Path);
				}
                else
                {
					Program.mainForm.SetProgress(5f, "Starting ESRGAN...");
					File.Delete(Paths.progressLogfile);
					string modelArg = GetModelArg(mdl);
					Logger.Log("Model Arg: " + modelArg);
					await Run(inpath, outpath, modelArg, tilesize, alpha, showTileProgress);
				}
				
				if (mode == PreviewMode.Cutout)
				{
					Program.mainForm.SetProgress(100f, "Merging into preview...");
					await Program.PutTaskDelay();
					PreviewMerger.Merge();
				}
				if (mode == PreviewMode.FullImage)
				{
					Program.mainForm.SetProgress(100f, "Merging into preview...");
					await Program.PutTaskDelay();
					Image outImg = ImgUtils.GetImage(Path.Combine(Paths.previewOutPath, "preview.png.tmp"));
					Image inputImg = ImgUtils.GetImage(Paths.tempImgPath);
					MainUIHelper.previewImg.Image = outImg;
					MainUIHelper.currentOriginal = inputImg;
					MainUIHelper.currentOutput = outImg;
					MainUIHelper.currentScale = ImgUtils.GetScale(inputImg, outImg);
					MainUIHelper.previewImg.ZoomToFit();
					Program.mainForm.SetProgress(0f, "Done.");
				}
			}
			catch(Exception e)
            {
				MessageBox.Show("An error occured during upscaling: \n\n" + e.Message, "Error");
				Logger.Log("Upscaling Error: " + e.Message + "\n" + e.StackTrace);
				Program.mainForm.SetProgress(0f, "Cancelled.");
			}
			
		}

		public static string GetModelArg (ModelData mdl)
        {
			string mdl1 = mdl.model1Path;
			string mdl2 = mdl.model2Path;
			ModelData.ModelMode mdlMode = mdl.mode;
			if(mdlMode == ModelData.ModelMode.Single)
            {
				Program.lastModelName = mdl.model1Name;
				return " --model \"" + mdl1 + "\"";
			}
			if (mdlMode == ModelData.ModelMode.Interp)
			{
				int interpLeft = 100 - mdl.interp;
				int interpRight = mdl.interp;
				Program.lastModelName = mdl.model1Name + ":" + interpLeft + ":" + mdl.model2Name + ":" + interpRight;
				return " --model \"" + mdl1 + "\";" + interpLeft + ";" + "\"" + mdl2 + "\";" + interpRight;
			}
			if (mdlMode == ModelData.ModelMode.Chain)
			{
				Program.lastModelName = mdl.model1Name + ">>" + mdl.model2Name;
				return " --prefilter  \"" + mdl1 + "\" --model \"" + mdl2 + "\"";
			}
			return null;
		}

		public static async Task Run(string inpath, string outpath, string modelArg, string tilesize, bool alpha, bool showTileProgress)
		{
			inpath = inpath.WrapPath();
			outpath = outpath.WrapPath();
			string alphaStr = " --noalpha";
			if (alpha)
				alphaStr = "";
			string deviceStr = " --device cuda";
			if(Config.GetBool("useCpu"))
				deviceStr = " --device cpu";
			string cmd2 = "/C cd /D \"" + Config.Get("esrganPath") + "\" & ";
			cmd2 = cmd2 + "python esrlmain.py " + inpath + " " + outpath + deviceStr + " --tilesize " + tilesize + alphaStr + modelArg;
			Logger.Log("CMD: " + cmd2);
			Process esrganProcess = new Process();
			esrganProcess.StartInfo.UseShellExecute = false;
			esrganProcess.StartInfo.RedirectStandardOutput = true;
			esrganProcess.StartInfo.RedirectStandardError = true;
			esrganProcess.StartInfo.CreateNoWindow = true;
			esrganProcess.StartInfo.FileName = "cmd.exe";
			esrganProcess.StartInfo.Arguments = cmd2;
			esrganProcess.OutputDataReceived += OutputHandler;
			esrganProcess.ErrorDataReceived += OutputHandler;
			currentProcess = esrganProcess;
			esrganProcess.Start();
			esrganProcess.BeginOutputReadLine();
			esrganProcess.BeginErrorReadLine();
			while (!esrganProcess.HasExited)
			{
				if(showTileProgress)
					await UpdateProgressFromFile();
				await Task.Delay(100);
			}
			if(Upscale.currentMode == Upscale.UpscaleMode.Batch)
            {
				await Task.Delay(1000);
				Program.mainForm.SetProgress(100f, "Post-Processing...");
				PostProcessingQueue.Stop();
			}
			File.Delete(Paths.progressLogfile);
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
			{
				return;
			}
			string data = output.Data;
			Logger.Log("[ESRGAN] " + data.Replace("\n", " ").Replace("\r", " "));
			if (data.Contains("RuntimeError"))
			{
				if (currentProcess != null && !currentProcess.HasExited)
				{
					currentProcess.Kill();
				}
				MessageBox.Show("Error occurred: \n\n" + data + "\n\nThe ESRGAN process was killed to avoid lock-ups.", "Error");
			}
			if (data.Contains("out of memory"))
				MessageBox.Show("ESRGAN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");

			if (data.Contains("Python was not found"))
				MessageBox.Show("Python was not found. Make sure you have a working Python 3 installation.", "Error");

			if (data.Contains("ModuleNotFoundError"))
				MessageBox.Show("You are missing ESRGAN Python dependencies. Make sure Pytorch, cv2 (opencv-python) and tensorboardx are installed.", "Error");

			if (data.Contains("RRDBNet"))
				MessageBox.Show("This model appears to be incompatible!", "Error");
		}

		static string lastProgressString = "";
		private static async Task UpdateProgressFromFile()
		{
			string progressLogFile = Paths.progressLogfile;
			if (!File.Exists(progressLogFile))
				return;
			string[] lines = IOUtils.ReadLines(progressLogFile);
			if (lines.Length <= 1)
				return;
			string outStr = (lines[lines.Length - 1]);
			if (outStr == lastProgressString)
				return;
			lastProgressString = outStr;
			string text = outStr.Replace("Tile ", "").Trim();
			int num = int.Parse(text.Split('/')[0]);
			int num2 = int.Parse(text.Split('/')[1]);
			float previewProgress = (float)num / (float)num2 * 100f;
			Program.mainForm.SetProgress(previewProgress, "Upscaling tiles - " + previewProgress.ToString("0") + "%");
			await Task.Delay(1);
		}

		public static string currentNcnnModel = "";

		public static async Task RunNcnn (string inpath, string outpath, string modelPath)
		{
			inpath = inpath.WrapPath();
			outpath = outpath.WrapPath();
			
			Program.mainForm.SetProgress(3f, "Converting NCNN model...");
			await NcnnUtils.ConvertNcnnModel(modelPath);
			Logger.Log("NCNN Model is ready: " + currentNcnnModel);
			Program.mainForm.SetProgress(5f, "Loading ESRGAN-NCNN...");
			int scale = NcnnUtils.GetNcnnModelScale(currentNcnnModel);
			string cmd2 = "/C cd /D \"" + Config.Get("esrganPath") + "\" & "
				+ "esrgan-ncnn-vulkan.exe -i " + inpath + " -o " + outpath + " -m " + currentNcnnModel.WrapPath() + " -s " + scale;
			Logger.Log("CMD: " + cmd2);
			Process ncnnProcess = new Process();
			ncnnProcess.StartInfo.UseShellExecute = false;
			ncnnProcess.StartInfo.RedirectStandardOutput = true;
			ncnnProcess.StartInfo.RedirectStandardError = true;
			ncnnProcess.StartInfo.CreateNoWindow = true;
			ncnnProcess.StartInfo.FileName = "cmd.exe";
			ncnnProcess.StartInfo.Arguments = cmd2;
			ncnnProcess.OutputDataReceived += NcnnOutputHandler;
			ncnnProcess.ErrorDataReceived += NcnnOutputHandler;
			currentProcess = ncnnProcess;
			ncnnProcess.Start();
			ncnnProcess.BeginOutputReadLine();
			ncnnProcess.BeginErrorReadLine();
			while (!ncnnProcess.HasExited)
			{
				await Task.Delay(100);
			}
			if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
			{
				await Task.Delay(1000);
				Program.mainForm.SetProgress(100f, "Post-Processing...");
				PostProcessingQueue.Stop();
			}
            else
            {
				//if(Upscale.currentMode == Upscale.UpscaleMode.Preview)
					//IOUtils.TrimFilenames(Paths.previewOutPath, 4, true, "*.tmp");

				//if (Upscale.currentMode == Upscale.UpscaleMode.Single)
					//IOUtils.TrimFilenames(Paths.imgOutPath, 4, true, "*.tmp");
			}
			File.Delete(Paths.progressLogfile);
		}

		private static void NcnnOutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
				return;

			string data = output.Data;
			Logger.Log("[NCNN] " + data.Replace("\n", " ").Replace("\r", " "));
			if (data.Contains("failed"))
			{
				if (currentProcess != null && !currentProcess.HasExited)
					currentProcess.Kill();

				MessageBox.Show("Error occurred: \n\n" + data + "\n\nThe ESRGAN-NCNN process was killed to avoid lock-ups.", "Error");
			}

			if (data.Contains("vkAllocateMemory"))
				MessageBox.Show("ESRGAN-NCNN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");
		}
	}
}
