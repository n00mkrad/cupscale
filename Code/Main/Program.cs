using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.OS;
using Cupscale.UI;
using ImageMagick;
using Win32Interop.Enums;
using Paths = Cupscale.IO.Paths;

[assembly: System.Windows.Media.DisableDpiAwareness] // Disable Dpi awareness in the application assembly.

namespace Cupscale
{
    internal static class Program
    {
        public static MainForm mainForm;
        public static string lastOutputDir;
        public static string lastImgPath;       // Single Image
        public static string lastDirPath;       // Batch
        public static string lastVidPath;       // Video
        public static string lastModelName;
        public static string currentModel1;
        public static string currentModel2;
        public static FilterType currentFilter = FilterType.Point;

        public static List<Form> currentTemporaryForms = new List<Form>();  // Temp forms that get closed when something gets cancelled
        public static List<MsgBox> openMessageBoxes = new List<MsgBox>();  // Temp forms that get closed when something gets cancelled

        public static bool lastUpscaleIsVideo;
        public static Process lastImpProcess;
        public static bool canceled = false;

        public static bool busy;

        [STAThread]
        private static void Main()
        {
            try
            {
                string lockfile = Path.Combine(Paths.GetDataPath(), "lockfile");
                File.Create(lockfile).Dispose();
                FileStream fs = File.Open(lockfile, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch
            {
                MessageBox.Show("Another instance of Cupscale seems to be running, accessing the following data folder:\n"
                    + Paths.GetDataPath() + ".\n\nMultiple instance are only possible if they use different data folders.\n"
                    + "Starting Cupscale with \"-portable\" will use the current directory as data folder.", "Error");
                return;
            }

            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.EnableVisualStyles();
            IoUtils.DeleteIfExists(Path.Combine(Paths.GetDataPath(), "sessionlog.txt"));
            Config.Init();
            Logger.Init();
            Paths.Init();
            AddBinsToPath();
            Implementations.Imps.Init();
            ResourceLimits.Memory = (ulong)Math.Round(ResourceLimits.Memory * 1.5f);
            OpenCL.IsEnabled = false;
            Cleanup();
            Application.Run(new MainForm());
        }

        private static void AddBinsToPath ()
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable($"PATH", path + $";{Paths.binPath}");
        }

        public static void Cancel (string reason = "", bool cleanup = true)
        {
            canceled = true;
            OsUtils.KillProcessTree(lastImpProcess);

            mainForm.SetProgress(0, "Canceled.");
            mainForm.SetBusy(false);

            if (reason.Trim().Length > 0)
                ShowMessage(reason);

            if (cleanup)
            {
                IoUtils.ClearDir(Paths.imgInPath);
                IoUtils.ClearDir(Paths.imgOutPath);
            }
        }

        public static MsgBox ShowMessage(string msg, string title = "Message")
        {
            DialogQueue.Init();
            MsgBox msgBox = new MsgBox(msg.Replace("\n", Environment.NewLine), title);
            DialogQueue.ShowDialog(msgBox);
            return msgBox;
        }

        public static void Cleanup()
        {
            try
            {
                IoUtils.ClearDir(Paths.previewPath);
                IoUtils.ClearDir(Paths.previewOutPath);
                IoUtils.ClearDir(Paths.clipboardFolderPath);
                IoUtils.ClearDir(Paths.imgInPath);
                IoUtils.ClearDir(Paths.imgOutPath);
                IoUtils.ClearDir(Paths.tempImgPath.GetParentDir());
                IoUtils.ClearDir(Path.Combine(Paths.GetDataPath(), "giftemp"));
                IoUtils.DeleteIfExists(Path.Combine(Paths.presetsPath, "lastUsed"));
                IoUtils.ClearDir(Paths.compositionOut);
                IoUtils.ClearDir(Paths.framesOutPath);
                IoUtils.DeleteIfExists(Path.Combine(Paths.GetDataPath(), "frames-out.mp4"));
            }
            catch (Exception e)
            {
                Logger.Log("Error during cleanup: " + e.Message);
            }
        }

        public static void CloseTempForms()
        {
            foreach (Form form in currentTemporaryForms.ToList())
                form.Close();
        }

        public static async Task PutTaskDelay()
        {
            await Task.Delay(1);
        }

        public static int GetPercentage(float val1, float val2)
        {
            return (int)Math.Round((val1 / val2) * 100f);
        }

        public static void Quit()
        {
            Application.Exit();
        }
    }
}
