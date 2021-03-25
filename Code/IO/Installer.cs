using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Cupscale.Forms;
using Cupscale.Properties;
using Cupscale.UI;

namespace Cupscale.IO
{
	internal class Installer
	{
		public static string path;
		public static int exeFilesVersion = -1;

		public static async Task Init()
		{
			exeFilesVersion = new StringReader(Resources.shipped_files_version).ReadLine().Split('#')[0].GetInt();
			Logger.Log($"[Installer] Initializing - Exe Files Version is {exeFilesVersion}.");
			path = Paths.esrganPath;

			if (!InstallationIsValid())
				await Install();
			else
				Logger.Log("[Installer] Installation is valid.");
		}

		public static bool InstallationIsValid ()
        {
			List<string> requiredDirs = new List<string>();
			requiredDirs.Add(Path.Combine(path, "Tools"));
			requiredDirs.Add(Path.Combine(path, "Tools", "Lib", "site-packages"));
			requiredDirs.Add(Path.Combine(path, "utils"));

			List<string> requiredFiles = new List<string>();
			requiredFiles.Add(Path.Combine(Paths.GetDataPath(), "shipped-files-version.txt"));
			requiredFiles.Add(Path.Combine(path, "upscale.py"));
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
					Logger.Log("[Installer] Installation invalid: Directory " + dir + " not found");
					return false;
				}
			}

			foreach (string file in requiredFiles)
			{
				if (!File.Exists(file))
				{
					Logger.Log("[Installer] Installation invalid: File " + file + " not found");
					return false;
				}
			}

			int diskVersion = IOUtils.ReadLines(Path.Combine(Paths.GetDataPath(), "shipped-files-version.txt"))[0].Split('#')[0].GetInt();
			if (exeFilesVersion != diskVersion)
            {
				Logger.Log("[Installer] Installation invalid: Shipped file version mismatch - Executable is " + exeFilesVersion + ", installation is " + diskVersion);
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

			if (IOUtils.GetDirSize(path) > 0)
			{
				Logger.Log("[Installer] {path} is not 0 bytes - removing everything there to ensure a clean install.");
				dialog.ChangeText("Uninstalling older files...");
				await Task.Delay(20);
				Uninstall(false);
			}

			Directory.CreateDirectory(path);

			path7za = Path.Combine(path, "7za.exe");
			File.WriteAllBytes(path7za, Resources.x64_7za);

            try
            {
				await DownloadAndInstall(exeFilesVersion, "esrgan.7z");
				await DownloadAndInstall(exeFilesVersion, "esrgan-ncnn.7z");
				await DownloadAndInstall(exeFilesVersion, "av.7z");
				await DownloadAndInstall(exeFilesVersion, "shipped-files-version.txt", false);
			}
            catch (Exception e)
            {
				MsgBox msg = Logger.ErrorMessage("Web Installer failed to run!\n", e);
				while (DialogQueue.IsOpen(msg)) await Task.Delay(50);
				Environment.Exit(1);
				return;
			}

			dialog.Close();
			Program.mainForm.Enabled = true;
			Program.mainForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			Program.mainForm.BringToFront();
		}

		static DialogForm currentDlDialog;

		static async Task DownloadAndInstall(int version, string filename, bool showDialog = true)
		{
			string savePath = Path.Combine(Paths.GetDataPath(), filename);
			string url = $"https://dl.nmkd.de/cupscale/shippedfiles/{version}/{filename}";
			Logger.Log($"[Installer] Downloading {url}");
			var client = new WebClient();
			currentDlDialog = new DialogForm($"Downloading {filename}…");
			sw.Restart();
			client.DownloadProgressChanged += DownloadProgressChanged;
			await client.DownloadFileTaskAsync(new Uri(url), savePath);
			if(Path.GetExtension(filename).ToLower() == ".7z")		// Only run extractor if it's a 7z archive
            {
				if (currentDlDialog != null)
					currentDlDialog.ChangeText($"Installing {filename}...");
				await UnSevenzip(Path.Combine(Paths.GetDataPath(), filename));
			}
			if(currentDlDialog != null)
				currentDlDialog.Close();
			currentDlDialog = null;
		}

		static Stopwatch sw = new Stopwatch();
		static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			if(sw.ElapsedMilliseconds > 250)
            {
				sw.Restart();
				string newText = currentDlDialog.GetText().Split('…')[0] + "… " + e.ProgressPercentage + "%";
				currentDlDialog.ChangeText(newText);
			}
		}

		static async Task UnSevenzip (string path)
        {
			Logger.Log("[Installer] Extracting " + path);
			await Task.Delay(20);
			SevenZipNET.SevenZipExtractor.Path7za = path7za;
			SevenZipNET.SevenZipExtractor extractor = new SevenZipNET.SevenZipExtractor(path);
			extractor.ExtractAll(Paths.GetDataPath(), true, true);
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
			if (!Directory.Exists(Paths.GetDataPath()))
				return;
            try
            {
				if (full)
					Directory.Delete(Paths.GetDataPath(), true);
				else
					Directory.Delete(path, true);
			}
			catch (Exception e)
            {
				Logger.Log("Failed to uninstall.\nClose Cupscale and try deleting %APPDATA%/Cupscale manually. " + e.Message);
            }
		}
	}
}
