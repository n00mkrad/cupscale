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
        public static Process currentEsrganProcess;
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
            IOUtils.DeleteIfExists(Path.Combine(Paths.GetDataPath(), "sessionlog.txt"));
            Config.Init();
            Logger.Init();
            Paths.Init();
            Implementations.Implementations.Init();
            ResourceLimits.Memory = (ulong)Math.Round(ResourceLimits.Memory * 1.5f);
            Cleanup();
            Application.Run(new MainForm());
        }

        public static void KillEsrgan (bool cleanup = true)
        {
            if (currentEsrganProcess == null || currentEsrganProcess.HasExited)
                return;
            canceled = true;
            OSUtils.KillProcessTree(currentEsrganProcess.Id);
            if (cleanup)
            {
                IOUtils.ClearDir(Paths.imgInPath);
                IOUtils.ClearDir(Paths.imgOutPath);
                IOUtils.ClearDir(Paths.imgOutNcnnPath);
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
                IOUtils.ClearDir(Paths.previewPath);
                IOUtils.ClearDir(Paths.previewOutPath);
                IOUtils.ClearDir(Paths.clipboardFolderPath);
                IOUtils.ClearDir(Paths.imgInPath);
                IOUtils.ClearDir(Paths.imgOutPath);
                IOUtils.ClearDir(Paths.imgOutNcnnPath);
                IOUtils.ClearDir(Paths.tempImgPath.GetParentDir());
                IOUtils.ClearDir(Path.Combine(Paths.GetDataPath(), "giftemp"));
                IOUtils.DeleteIfExists(Path.Combine(Paths.presetsPath, "lastUsed"));
                IOUtils.ClearDir(Paths.compositionOut);
                IOUtils.ClearDir(Paths.framesOutPath);
                IOUtils.DeleteIfExists(Path.Combine(Paths.GetDataPath(), "frames-out.mp4"));
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
