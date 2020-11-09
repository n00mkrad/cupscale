using Cupscale.Cupscale;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.OS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.UI
{
    class VideoUpscaleUI
    {
        static TextBox outDir;
        static TextBox logBox;
        static Label titleLabel;

        static string currentInPath;
        static string currentParentDir;

        //static string framesPath;

        public static void Init(TextBox outDirBox, TextBox logTextbox, Label mainLabel)
        {
            outDir = outDirBox;
            logBox = logTextbox;
            titleLabel = mainLabel;
        }

        public static void LoadFile(string path)
        {
            if (!IOUtils.videoExtensions.Contains(Path.GetExtension(path)))
            {
                Program.ShowMessage("Not a supported video file!");
                return;
            }
            outDir.Text = path;
            currentInPath = path.Trim();
            currentParentDir = path.Trim().GetParentDir();
            Program.lastVidPath = currentInPath;
            TabSelected();
        }

        public static void TabSelected()
        {
            Program.mainForm.SetButtonText("Upscale Video");
            if (string.IsNullOrWhiteSpace(currentInPath))
                return;
            titleLabel.Text = "Loaded " + currentInPath.Wrap();
        }

        public static async Task Run ()
        {
            Print("Starting upscale of " + Path.GetFileName(currentInPath));
            if (!IOUtils.HasEnoughDiskSpace(IOUtils.GetAppDataDir(), 10.0f))
            {
                Program.ShowMessage($"Not enough disk space on {IOUtils.GetAppDataDir().Substring(0, 3)} to store temporary files!", "Error");
                return;
            }
            IOUtils.ClearDir(Paths.imgInPath);
            Print("Extracting frames...");
            await FFmpegCommands.VideoToFrames(currentInPath, Paths.imgInPath, false, false, false);
            int amountFrames = IOUtils.GetAmountOfCompatibleFiles(Paths.imgInPath, false);
            Print($"Done - Extracted  {amountFrames} frames.");
            Print("Upscaling frames...");
            BatchUpscaleUI.LoadDir(Paths.imgInPath);
            await BatchUpscaleUI.Run(false, false, Paths.imgOutPath);
            Print("Done upscaling all frames.");
        }


        static void Print(string s, bool replaceLastLine = false)
        {
            if (replaceLastLine)
            {
                logBox.Text = logBox.Text.Remove(logBox.Text.LastIndexOf(Environment.NewLine));
            }
            if (string.IsNullOrWhiteSpace(logBox.Text))
                logBox.Text += s;
            else
                logBox.Text += Environment.NewLine + s;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
    }
}
