using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Cupscale.Forms;
using Cupscale.Properties;
using Cupscale.UI;

namespace Cupscale.IO
{
	internal class ShippedFiles
	{
		public static string path;

		public static async Task Init()
		{
			Logger.Log("[ShippedFiles] Init()");
			path = Paths.esrganPath;
			if (!InstallationIsValid())
				await Install();
			else
				Logger.Log("[ShippedFiles] Installation is valid.");
		}

		public static bool InstallationIsValid ()
        {
			List<string> requiredDirs = new List<string>();
			requiredDirs.Add(Path.Combine(path, "Tools"));
			requiredDirs.Add(Path.Combine(path, "Tools", "Lib", "site-packages"));
			requiredDirs.Add(Path.Combine(path, "utils"));

			List<string> requiredFiles = new List<string>();
			requiredFiles.Add(Path.Combine(IOUtils.GetAppDataDir(), "shipped_files_version"));
			requiredFiles.Add(Path.Combine(path, "esrlmain.py"));
			requiredFiles.Add(Path.Combine(path, "esrlupscale.py"));
			requiredFiles.Add(Path.Combine(path, "esrlmodel.py"));
			requiredFiles.Add(Path.Combine(path, "esrlrrdbnet.py"));
			requiredFiles.Add(Path.Combine(path, "ffmpeg.exe"));
			requiredFiles.Add(Path.Combine(path, "esrgan-ncnn-vulkan.exe"));
			requiredFiles.Add(Path.Combine(path, "pth2ncnn.exe"));
			requiredFiles.Add(Path.Combine(path, "nvcompress.exe"));
			requiredFiles.Add(Path.Combine(path, "nvtt.dll"));
			requiredFiles.Add(Path.Combine(path, "gifski.exe"));

			foreach (string dir in requiredDirs)
            {
				if (!Directory.Exists(dir))
				{
					Logger.Log("[ShippedFiles] Installation invalid: Directory " + dir + " not found");
					return false;
				}
			}

			foreach (string file in requiredFiles)
			{
				if (!File.Exists(file))
				{
					Logger.Log("[ShippedFiles] Installation invalid: File " + file + " not found");
					return false;
				}
			}

			int exeVersion = new StringReader(Resources.shipped_files_version).ReadLine().Split('#')[0].GetInt();
			int diskVersion = IOUtils.ReadLines(Path.Combine(IOUtils.GetAppDataDir(), "shipped_files_version"))[0].Split('#')[0].GetInt();
			if (exeVersion != diskVersion)
            {
				Logger.Log("[ShippedFiles] Installation invalid: Shipped file version mismatch - Executable is " + exeVersion + ", installation is " + diskVersion);
				return false;
			}

			return true;
		}

		static string path7za = "";

		public static async Task Install ()
		{
			Program.mainForm.Enabled = false;
			DialogForm dialog = new DialogForm("Installing resources...\nThis only needs to be done once.");
			await Task.Delay(20);
			Directory.CreateDirectory(path);

			path7za = Path.Combine(path, "7za.exe");
			File.WriteAllBytes(path7za, Resources.x64_7za);
			// File.WriteAllBytes(Path.Combine(path, "nvcompress.exe"), Resources.nvcompress);
			// File.WriteAllBytes(Path.Combine(path, "nvtt.dll"), Resources.nvtt);
			File.WriteAllBytes(Path.Combine(IOUtils.GetAppDataDir(), "esrgan.7z"), Resources.esrgan);
			File.WriteAllBytes(Path.Combine(IOUtils.GetAppDataDir(), "ncnn.7z"), Resources.esrgan_ncnn);
			File.WriteAllBytes(Path.Combine(IOUtils.GetAppDataDir(), "av.7z"), Resources.av);

			dialog.ChangeText("Installing ESRGAN resources...");
			await UnSevenzip(Path.Combine(IOUtils.GetAppDataDir(), "esrgan.7z"));
			dialog.ChangeText("Installing ESRGAN-NCNN resources...");
			await UnSevenzip(Path.Combine(IOUtils.GetAppDataDir(), "ncnn.7z"));
			dialog.ChangeText("Installing FFmpeg resources...");
			await UnSevenzip(Path.Combine(IOUtils.GetAppDataDir(), "av.7z"));

			File.WriteAllText(Path.Combine(IOUtils.GetAppDataDir(), "shipped_files_version"), Resources.shipped_files_version);

			dialog.Close();
			Program.mainForm.Enabled = true;
			Program.mainForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			Program.mainForm.BringToFront();
		}

		static async Task UnSevenzip (string path)
        {
			Logger.Log("[ShippedFiles] Extracting " + path);
			await Task.Delay(20);
			SevenZipNET.SevenZipExtractor.Path7za = path7za;
			SevenZipNET.SevenZipExtractor extractor = new SevenZipNET.SevenZipExtractor(path);
			extractor.ExtractAll(IOUtils.GetAppDataDir(), true, true);
			File.Delete(path);
			await Task.Delay(10);
		}

		public static bool Exists()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo == null || !Directory.Exists(directoryInfo.FullName))
			{
				return false;
			}
			FileInfo[] files = directoryInfo.GetFiles("*.py", SearchOption.AllDirectories);
			if (files.Length >= 4)
			{
				return true;
			}
			return false;
		}

		public static void Uninstall (bool full)
        { 
			if (full)
				Directory.Delete(IOUtils.GetAppDataDir(), true);
			else
				Directory.Delete(path, true);
		}
	}
}
