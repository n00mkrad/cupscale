using Cupscale.Forms;
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
				DialogForm dialog = new DialogForm("Converting ESRGAN model to NCNN format...");
				await RunConverter(modelPath);
				string moveFrom = Path.Combine(Config.Get("esrganPath"), Path.ChangeExtension(modelName, null));
				Logger.Log("Moving " + moveFrom + " to " + outPath);
				await IOUtils.CopyDir(moveFrom, outPath, "*", true);
				Directory.Delete(moveFrom, true);
				dialog.Close();
			}
            else
            {
				Logger.Log("NCNN Model is cached - Skipping conversion.");
			}
			ESRGAN.currentNcnnModel = outPath;
        }

		static async Task RunConverter(string modelPath)
		{
			bool showWindow = Config.GetInt("cmdDebugMode") > 0;
			bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

			modelPath = modelPath.Wrap();

			string opt = "/C";
			if (stayOpen) opt = "/K";

			string args = $"{opt} cd /D {Config.Get("esrganPath").Wrap()} & pth2ncnn.exe {modelPath}";

			Logger.Log("[CMD] " + args);
			Process converterProc = OSUtils.NewProcess(!showWindow);
			converterProc.StartInfo.Arguments = args;
			if (!showWindow)
			{
				converterProc.OutputDataReceived += OutputHandler;
				converterProc.ErrorDataReceived += OutputHandler;
			}
			currentProcess = converterProc;
			converterProc.Start();
			if (!showWindow)
			{
				converterProc.BeginOutputReadLine();
				converterProc.BeginErrorReadLine();
			}
			while (!converterProc.HasExited)
				await Task.Delay(100);

			File.Delete(Paths.progressLogfile);
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
				return;

			string data = output.Data;
			Logger.Log("[NcnnUtils] Model Converter Output: " + data);
		}

		public static int GetNcnnModelScale(string modelDir)
		{
			string[] files = Directory.GetFiles(modelDir, "*.bin");
			return Path.GetFileNameWithoutExtension(files[0]).GetInt();
		}
	}
}
