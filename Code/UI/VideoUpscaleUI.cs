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

        static float currentFps;
        static string currentExt = ".mp4";

        public static void Init(TextBox outDirBox, TextBox logTextbox, Label mainLabel)
        {
            outDir = outDirBox;
            logBox = logTextbox;
            titleLabel = mainLabel;
        }

        public static void LoadFile(string path)
        {
            if (!IOUtils.videoExtensions.Contains(Path.GetExtension(path).ToLower()))
            {
                Program.ShowMessage("Not a supported video file!");
                return;
            }
            currentInPath = path.Trim();
            currentParentDir = path.Trim().GetParentDir();
            outDir.Text = currentParentDir;
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
            logBox.Clear();
            Print("Starting upscale of " + Path.GetFileName(currentInPath));
            if (string.IsNullOrWhiteSpace(currentInPath) || !File.Exists(currentInPath))
            {
                Program.ShowMessage("No valid file loaded.", "Error");
                return;
            }
            if (!IOUtils.HasEnoughDiskSpace(IOUtils.GetAppDataDir(), 10.0f))
            {
                Program.ShowMessage($"Not enough disk space on {IOUtils.GetAppDataDir().Substring(0, 3)} to store temporary files!", "Error");
                return;
            }
            IOUtils.ClearDir(Paths.framesOutPath);
            currentFps = FFmpegCommands.GetFramerate(currentInPath);
            Print("Detected frame rate of video as " + currentFps);
            IOUtils.ClearDir(Paths.imgInPath);
            Print("Extracting frames...");
            await FFmpegCommands.VideoToFrames(currentInPath, Paths.imgInPath, false, false, false);
            int amountFrames = IOUtils.GetAmountOfCompatibleFiles(Paths.imgInPath, false);
            Print($"Done - Extracted  {amountFrames} frames{Environment.NewLine}Upscaling frames...");
            BatchUpscaleUI.LoadDir(Paths.imgInPath);
            await BatchUpscaleUI.Run(false, true, Paths.framesOutPath);
            RenameOutFiles();
            Print($"Done upscaling all frames.{Environment.NewLine}Creating video from frames...");
            await FFmpegCommands.FramesToMp4(Paths.framesOutPath, Config.GetBool("h265"), Config.GetInt("crf"), currentFps, "", false);
            Print($"Done creating video.");
            CopyBack(Path.Combine(IOUtils.GetAppDataDir(), "frames-out.mp4"));
            IOUtils.ClearDir(Paths.imgInPath);
            IOUtils.ClearDir(Paths.framesOutPath);
            Print("Done.");
        }

        static void CopyBack (string path)
        {
            string filename = Path.GetFileNameWithoutExtension(currentInPath);
            string ext = Path.GetExtension(path);
            string outPath = "";

            if (Upscale.overwriteMode == Upscale.Overwrite.No)
                outPath = Path.Combine(outDir.Text.Trim(), filename + "-" + Program.lastModelName + ext);
            else
                outPath = Path.Combine(outDir.Text.Trim(), Path.GetFileName(currentInPath));

            outPath = Path.ChangeExtension(outPath, currentExt);
            Print("Moving output video to " + outPath + "...");
            File.Move(path, outPath);
        }

        static void RenameOutFiles ()
        {
            string[] frames = IOUtils.GetCompatibleFiles(Paths.framesOutPath, false);
            foreach(string frame in frames)
            {
                if (frame.Contains("-"))
                {
                    string filename = Path.GetFileName(frame);
                    string newFilename = Path.GetFileName(frame).Split('-')[0];
                    string newPath = Path.Combine(frame.GetParentDir(), newFilename + Path.GetExtension(frame));
                    Logger.Log("NewPath: " + newPath);
                    File.Move(frame, newPath);
                }
            }
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
