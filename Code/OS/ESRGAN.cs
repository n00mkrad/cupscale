using Cupscale.ImageUtils;
using Cupscale.IO;
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
		

		public static async Task UpscaleBasic(string inpath, string outpath, ModelData mdl, string tilesize, bool alpha, PreviewMode mode, bool showTileProgress = true)
		{
            try
            {
				string modelArg = GetModelArg(mdl);
				Logger.Log("Model Arg: " + modelArg);
				Program.mainForm.SetProgress(5f, "Starting ESRGAN...");
				await Run(inpath, outpath, modelArg, tilesize, alpha, showTileProgress);
				File.Delete(Paths.progressLogfile);
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
					Image outImg = IOUtils.GetImage(Path.Combine(Paths.previewOutPath, "preview.png"));
					Image inputImg = IOUtils.GetImage(Paths.tempImgPath);
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
            }
			
		}

		public static string GetModelArg (ModelData mdl)
        {
			string mdl1 = mdl.model1Path;
			string mdl2 = mdl.model2Path;
			ModelData.ModelMode mdlMode = mdl.mode;
			string mdlPath = Config.Get("modelPath").Replace("/", "\\").TrimEnd('\\');
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
			inpath = "\"" + inpath + "\"";
			outpath = "\"" + outpath + "\"";
			string alphaStr = " --noalpha";
			if (alpha)
			{
				alphaStr = "";
			}
			string cmd2 = "/C cd /D \"" + Config.Get("esrganPath") + "\" & ";
			cmd2 = cmd2 + "python esrlmain.py " + inpath + " " + outpath + " --tilesize " + tilesize + alphaStr + modelArg;
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
			File.Delete(Paths.progressLogfile);
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
			{
				return;
			}
			string data = output.Data;
			Logger.Log(data.Replace("\n", " ").Replace("\r", " "));
			if (data.Contains("RuntimeError"))
			{
				if (currentProcess != null && !currentProcess.HasExited)
				{
					currentProcess.Kill();
				}
				MessageBox.Show("Error occurred: \n\n" + data + "\n\nThe ESRGAN process was killed to avoid lock-ups.", "Error");
			}
			if (data.Contains("out of memory"))
			{
				MessageBox.Show("ESRGAN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");
			}
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
			Logger.Log("Progress from log file: " + outStr);
			string text = outStr.Replace("Tile ", "").Trim();
			int num = int.Parse(text.Split('/')[0]);
			int num2 = int.Parse(text.Split('/')[1]);
			float previewProgress = (float)num / (float)num2 * 100f;
			Logger.Log(" = " + previewProgress);
			Program.mainForm.SetProgress(previewProgress, "Upscaling tiles - " + previewProgress.ToString("0") + "%");
			await Task.Delay(1);
		}
	}
}
