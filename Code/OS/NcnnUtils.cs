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
    class NcnnUtils
    {
		static Process currentProcess;
		static string ncnnDir = "";

		public static async Task ConvertNcnnModel(string modelPath)
        {
			string modelName = Path.GetFileName(modelPath);
			ncnnDir = Path.Combine(Config.Get("modelPath"), ".ncnn");
			Directory.CreateDirectory(ncnnDir);
			string outPath = Path.Combine(ncnnDir, Path.ChangeExtension(modelName, null));
			Logger.Log("Checking for NCNN model: " + outPath);
			if (IOUtils.GetAmountOfFiles(outPath, false) < 2)
            {
				Logger.Log("Running model converter...");
				await RunConverter(modelPath);
				string moveFrom = Path.Combine(Config.Get("esrganPath"), Path.ChangeExtension(modelName, null));
				Logger.Log("Moving " + moveFrom + " to " + outPath);
				IOUtils.Copy(moveFrom, outPath, true);
				Directory.Delete(moveFrom, true);
			}
            else
            {
				Logger.Log("NCNN Model is cached - Skipping conversion.");
			}
			ESRGAN.currentNcnnModel = outPath;
        }

		static async Task RunConverter(string modelPath)
		{
			modelPath = modelPath.WrapPath();

			string cmd2 = "/C cd /D " + Config.Get("esrganPath").WrapPath() + " & pth2ncnn.exe " + modelPath;

			Logger.Log("CMD: " + cmd2);
			Process converterProc = new Process();
			//converterProc.StartInfo.UseShellExecute = false;
			//converterProc.StartInfo.RedirectStandardOutput = true;
			//converterProc.StartInfo.RedirectStandardError = true;
			//converterProc.StartInfo.CreateNoWindow = true;
			converterProc.StartInfo.FileName = "cmd.exe";
			converterProc.StartInfo.Arguments = cmd2;
			converterProc.OutputDataReceived += OutputHandler;
			converterProc.ErrorDataReceived += OutputHandler;
			currentProcess = converterProc;
			converterProc.Start();
			//converterProc.BeginOutputReadLine();
			//converterProc.BeginErrorReadLine();
			while (!converterProc.HasExited)
			{
				await Task.Delay(100);
			}
			File.Delete(Paths.progressLogfile);
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
				return;

			string data = output.Data;
			Logger.Log("Model Converter Output: " + data);
		}

		public static int GetNcnnModelScale(string modelDir)
		{
			string[] files = Directory.GetFiles(modelDir, "*.bin");
			return Path.GetFileNameWithoutExtension(files[0]).GetInt();
		}
	}
}
