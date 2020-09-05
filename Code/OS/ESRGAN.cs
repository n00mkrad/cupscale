using Cupscale.IO;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.OS
{
	internal class ESRGAN
	{
		private static Process currentProcess;

		public static async Task UpscaleBasic(string inpath, string outpath, string model, string tilesize, bool alpha, bool isPreview = false)
		{
			string formattedModelPath = Config.Get("modelPath").Replace("/", "\\").TrimEnd('\\');
			string modelArg = "\"" + formattedModelPath + "/" + model + ".pth\"";
			Program.mainForm.SetPreviewProgress(5f, "Starting ESRGAN...");
			await Run(inpath, outpath, modelArg, tilesize, alpha);
			File.Delete(Paths.progressLogfile);
			if (isPreview)
			{
				Program.mainForm.SetPreviewProgress(100f, "Merging into preview...");
				await Program.PutTaskDelay();
				PreviewMerger.Merge();
			}
		}

		public static async Task Run(string inpath, string outpath, string modelArg, string tilesize, bool alpha)
		{
			inpath = "\"" + inpath + "\"";
			outpath = "\"" + outpath + "\"";
			string alphaStr = " --noalpha";
			if (alpha)
			{
				alphaStr = "";
			}
			string cmd2 = "/C cd /D \"" + Config.Get("esrganPath") + "\" & ";
			cmd2 = cmd2 + "python esrlmain.py " + inpath + " " + outpath + " --tilesize " + tilesize + alphaStr + " --model " + modelArg;
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
				UpdateProgressFromFile();
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
		private static void UpdateProgressFromFile()
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
			Program.mainForm.SetPreviewProgress(previewProgress, "Upscaling tiles - " + previewProgress.ToString("0") + "%");
		}
	}
}
