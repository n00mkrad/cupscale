using Cupscale.Forms;
using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Win32Interop.Structs;

namespace Cupscale.OS
{
    class EmbeddedPython
    {
        public static string GetPyCmd()
        {
            if (IsEnabled())
                return GetEmbedPyPath().Wrap();
            else
                return "python";
        }

        public static string GetEmbedPyPath()
        {
            return Path.Combine(Installer.path, "py", "python.exe");
        }

        public static bool IsEnabled()
        {
            return Config.GetInt("pythonRuntime") == 1;
        }

        public static async Task Init()
        {
            if (!IsEnabled()) return;
            string shippedPath = Installer.path;
            IOUtils.TryDeleteIfExists(Path.Combine(shippedPath, "py", "utils"));
            await IOUtils.CopyDir(Path.Combine(shippedPath, "utils"), Path.Combine(shippedPath, "py", "utils"));
            File.Copy(Path.Combine(shippedPath, "esrlupscale.py"), Path.Combine(shippedPath, "py", "esrlupscale.py"), true);
            File.Copy(Path.Combine(shippedPath, "esrlmodel.py"), Path.Combine(shippedPath, "py", "esrlmodel.py"), true);
            File.Copy(Path.Combine(shippedPath, "esrlrrdbnet.py"), Path.Combine(shippedPath, "py", "esrlrrdbnet.py"), true);
        }

        static TextBox logBox;
        static HTAlt.WinForms.HTButton runBtn;
        static string downloadPath;
        static string extractPath;

        public static async Task Download(TextBox logTextbox, HTAlt.WinForms.HTButton runButton)
        {
            logBox = logTextbox;
            runBtn = runButton;
            runBtn.Enabled = false;
            Print("Initializing...");
            downloadPath = Path.Combine(Installer.path, "py.7z");
            extractPath = Path.Combine(Installer.path, "py");
            isExtracting = false;

            await Task.Delay(10);

            Print("Checking disk space before installation...");
            float diskSpaceMb = IOUtils.GetDiskSpace(Paths.GetDataPath());
            Print($"Available disk space on the current drive: {diskSpaceMb} MB.");
            if (diskSpaceMb < 5000)
            {
                Print("Not enough disk space on the current drive!");
                runBtn.Enabled = true;
                return;
            }

            IOUtils.DeleteIfExists(downloadPath);
            await Task.Delay(10);

            Print("Downloading compressed python runtime...");
            var client = new WebClient();
            client.DownloadProgressChanged += DownloadProgressChanged;
            client.DownloadFileAsync(new Uri("https://dl.nmkd.de/ai/python/py.7z"), downloadPath);
            client.DownloadFileCompleted += DoneDownloading;
        }

        static void DoneDownloading (object sender, AsyncCompletedEventArgs e)
        {
            Install();
        }

        static async Task Install ()
        {
            Print("Done downloading!");
            Print("Extracting...");
            if (Directory.Exists(extractPath))
                IOUtils.ClearDir(extractPath);
            List<Task> tasks = new List<Task>();
            isExtracting = true;
            tasks.Add(CheckDownloadedFileSizeAsync());
            tasks.Add(ExtractAsync());
            await Task.WhenAll(tasks);
            Print("Done extracting files.");
            MsgBox msg = Program.ShowMessage("The Python files will now be compressed to reduce the amount of storage space needed " +
                "from 2.4 GB to 1.6 GB.\nThis can take a few minutes.", "Message");
            while (DialogQueue.IsOpen(msg)) await Task.Delay(50);
            Print("Compressing files...");
            RunCompact();
            Print("Done!");
            Config.Set("pythonRuntime", "1");
            await Init();
            MsgBox msg2 = Program.ShowMessage("Installed embedded Python runtime and enabled it!\nIf you want to disable it, you can do so in the settings.", "Message");
            while (DialogQueue.IsOpen(msg2)) await Task.Delay(50);
            runBtn.Enabled = true;
        }

        static void RunCompact ()
        {
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;
            string opt = "/C";
            if (stayOpen) opt = "/K";
            Process compact = OSUtils.NewProcess(false);
            compact.StartInfo.Arguments = $"{opt} compact /C /S:{extractPath.Wrap()}";
            compact.Start();
            Thread.Sleep(100);  // <-- ugly hack https://stackoverflow.com/a/1016863/14274419
            SetWindowText(compact.MainWindowHandle, "Compressing Python installation... Do not close this window!");
            compact.WaitForExit();
        }

        static int lastPercentage = 0;
        static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int diff = Math.Abs(lastPercentage - e.ProgressPercentage);
            if(diff >= 1)
            {
                lastPercentage = e.ProgressPercentage;
                Print("Downloading compressed python runtime - " + e.ProgressPercentage + "%", true);
            }
        }

        static bool isExtracting;
        static async Task ExtractAsync()
        {
            await Task.Run(async () =>
            {
                SevenZipNET.SevenZipExtractor.Path7za = Path.Combine(Installer.path, "7za.exe");
                SevenZipNET.SevenZipExtractor extractor = new SevenZipNET.SevenZipExtractor(downloadPath);
                await Task.Delay(1);
                extractor.ExtractAll(Installer.path, true, true);
                File.Delete(downloadPath);
                isExtracting = false;
            });
        }

        static async Task CheckDownloadedFileSizeAsync()
        {
            await Task.Run(async () =>
            {
                while (isExtracting)
                {
                    try
                    {
                        if (Directory.Exists(extractPath))
                        {
                            long currentBytes = IOUtils.GetDirSize(extractPath, true);
                            int mb = (int)(currentBytes / 1024f / 1000f);
                            Print("Installed " + mb + " MB of 2500", true);
                        }
                    }
                    catch (Exception e)
                    {
                        Print("Error: " + e.Message);
                    }
                    await Task.Delay(3000);
                }
            });
        }

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        static void Print(string s, bool replaceLastLine = false)
        {
            if (replaceLastLine)
            {
                logBox.Text = logBox.Text.Remove(logBox.Text.LastIndexOf(Environment.NewLine));
            }
            if(string.IsNullOrWhiteSpace(logBox.Text))
                logBox.Text += s;
            else
                logBox.Text += Environment.NewLine + s;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
    }
}
