using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class NvCompress
    {
		static Process currentProcess;

        public static async Task PngToDds (string inputFile, string outputPath)
        {
			string dxtString = Config.Get("dxtMode").ToLower().Replace("argb", "rgb");
			if (dxtString.Contains(" "))
				dxtString = dxtString.Split(' ')[0];
			await Run(inputFile, outputPath, dxtString, Config.GetBool("alpha"), Config.GetBool("ddsEnableMips"));

		}

		public static async Task Run(string inpath, string outpath, string dxtMode, bool alpha, bool enableMips)
		{
			bool showWindow = Config.GetInt("cmdDebugMode") > 0;
			bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            if (Path.GetExtension(inpath).ToLower() != ".png")
            {
				string newPath = Path.ChangeExtension(inpath, "png");
				File.Move(inpath, newPath);
				inpath = newPath;
            }

			string alphaStr = "";
			if (alpha)
				alphaStr = "-alpha";

			string mipStr = "-nomips";
			if (enableMips)
				mipStr = "";

			string opt = "/C";
			if (stayOpen) opt = "/K";

			string args = $"{opt} cd /D {Paths.implementationsPath.Wrap()} & ";
			args += $"nvcompress.exe -{dxtMode} {alphaStr} {mipStr} {inpath.Wrap()} {outpath.Wrap()}";
			Logger.Log("[CMD] " + args);
			Process nvCompress = new Process();
			nvCompress.StartInfo.UseShellExecute = showWindow;
			nvCompress.StartInfo.RedirectStandardOutput = !showWindow;
			nvCompress.StartInfo.RedirectStandardError = !showWindow;
			nvCompress.StartInfo.CreateNoWindow = !showWindow;
			nvCompress.StartInfo.FileName = "cmd.exe";
			nvCompress.StartInfo.Arguments = args;
            if (!showWindow)
            {
				nvCompress.OutputDataReceived += OutputHandler;
				nvCompress.ErrorDataReceived += OutputHandler;
			}
			currentProcess = nvCompress;
			nvCompress.Start();
			if (!showWindow)
			{
				nvCompress.BeginOutputReadLine();
				nvCompress.BeginErrorReadLine();
			}

			while (!nvCompress.HasExited)
				await Task.Delay(50);

			if (inpath.ToLower() != outpath.ToLower())
				File.Delete(inpath);
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
		{
			if (output == null || output.Data == null)
				return;

			string data = output.Data;

			if(data.Length >= 4)
				Logger.Log("[NvCompress] " + data.Replace("\n", " ").Replace("\r", " "));
		}
	}
}
