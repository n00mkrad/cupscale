using Cupscale.Cupscale;
using Cupscale.Forms;
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
        static ComboBox outputFormatBox;

        static Upscale.VidExportMode outputFormat = Upscale.VidExportMode.MP4;

        static string currentInPath;
        static string currentParentDir;

        static float fps;

        public static void Init(TextBox outDirBox, TextBox logTextbox, Label mainLabel, ComboBox outFormatBox)
        {
            outDir = outDirBox;
            logBox = logTextbox;
            titleLabel = mainLabel;
            outputFormatBox = outFormatBox;
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

        public static async Task Run(bool preprocess)
        {
            logBox.Clear();
            Print("Starting upscale of " + Path.GetFileName(currentInPath));

            if (string.IsNullOrWhiteSpace(currentInPath) || !File.Exists(currentInPath))
            {
                Program.ShowMessage("No valid file loaded.", "Error");
                return;
            }

            Program.mainForm.SetBusy(true);
            LoadVideo();
            Print("Extracting frames...");
            await FFmpegCommands.VideoToFrames(currentInPath, Paths.imgInPath, false, false, false);
            int amountFrames = IOUtils.GetAmountOfCompatibleFiles(Paths.imgInPath, false);
            Print($"Done - Extracted {amountFrames} frames.");
            await PreprocessIfNeeded(preprocess);
            BatchUpscaleUI.LoadDir(Paths.imgInPath, true);
            Print("Upscaling frames...");
            await BatchUpscaleUI.Run(false, true, false, Paths.framesOutPath);
            RenameOutFiles();
            Print($"Done upscaling all frames.");
            BatchUpscaleUI.Reset();
            Print("Creating video from frames...");
            await CreateVideo();
            Print("Done creating video.");
            CopyBack(Path.Combine(Paths.GetDataPath(), "frames-out.mp4"));
            Print("Adding audio from source to output video...");
            IOUtils.ClearDir(Paths.imgInPath);
            IOUtils.ClearDir(Paths.framesOutPath);
            Program.mainForm.SetBusy(false);
            Print("Finished.");
        }

        static void LoadVideo()
        {
            IOUtils.ClearDir(Paths.framesOutPath);
            fps = FFmpegCommands.GetFramerate(currentInPath);
            Print("Detected frame rate of video as " + fps);
            IOUtils.ClearDir(Paths.imgInPath);
        }

        static async Task PreprocessIfNeeded(bool doPreprocess)
        {
            if (doPreprocess)   // Skip if target scale is 100%
            {
                Print("Preprocessing frames...");
                await Task.Delay(10);
                await ImageProcessing.PreProcessImages(Paths.imgInPath, !bool.Parse(Config.Get("alpha")));
                Print("Done preprocessing.");
            }
            else
            {
                Print("Preprocessing is disabled, using raw extracted frames.");
            }
        }

        static async Task PostprocessIfNeeded()
        {
            if (!(ImageProcessing.postScaleMode == Upscale.ScaleMode.Percent && ImageProcessing.postScaleValue == 100))   // Skip if target scale is 100%
            {
                Print("Post-Resizing is enabled - Postprocessing frames...");
                await Task.Delay(10);
                string[] imgs = IOUtils.GetCompatibleFiles(Paths.imgOutPath, false, "*.png");
                int i = 0;
                foreach (string img in imgs)
                {
                    await ImageProcessing.PostProcessImage(img, ImageProcessing.Format.PngFast, false);
                    i++;
                    Program.mainForm.SetProgress(Program.GetPercentage(i, imgs.Length), "Resizing " + Path.GetFileName(img));
                }
                Print("Done postprocessing.");
            }
        }

        static async Task CreateVideo()
        {
            if (IOUtils.GetAmountOfFiles(Paths.framesOutPath, false) < 1) return;

            if (outputFormatBox.Text == Upscale.VidExportMode.MP4.ToStringTitleCase())
                outputFormat = Upscale.VidExportMode.MP4;
            if (outputFormatBox.Text == Upscale.VidExportMode.GIF.ToStringTitleCase())
                outputFormat = Upscale.VidExportMode.GIF;
            if (outputFormatBox.Text == Upscale.VidExportMode.SameAsSource.ToStringTitleCase())
                outputFormat = (Upscale.VidExportMode)Enum.Parse(typeof(Upscale.VidExportMode), Path.GetExtension(currentInPath).Replace(".", "").ToUpper());

            if (outputFormat == Upscale.VidExportMode.MP4)
            {
                DialogForm f = new DialogForm("Creating video from frames...", 300);
                await Task.Delay(10);
                await FFmpegCommands.FramesToMp4(Paths.framesOutPath, Config.GetBool("h265"), Config.GetInt("crf"), fps, "", false);
                if (Config.GetBool("vidEnableAudio"))
                    await FFmpegCommands.MergeAudio(Paths.framesOutPath + ".mp4", currentInPath);
                f.Close();
            }

            if (outputFormat == Upscale.VidExportMode.GIF)
            {
                DialogForm f = new DialogForm("Creating GIF from frames...\nThis can take a while for high-resolution GIFs.", 600);
                await Task.Delay(10);
                string outpath = Path.Combine(Paths.GetDataPath(), "frames-out.mp4").Wrap();
                await FFmpeg.RunGifski($" -r {fps.RoundToInt()} -W 4096 -Q {Config.GetInt("gifskiQ")} -q -o {outpath} \"{Paths.framesOutPath}/\"*.\"png\"");
                f.Close();
            }
        }

        static void CopyBack(string path)
        {
            if (!File.Exists(path))
            {
                Print("No video file was created!");
                return;
            }

            string filename = Path.GetFileNameWithoutExtension(currentInPath);
            string ext = Path.GetExtension(path);
            string outPath = "";

            try
            {
                if (Upscale.overwriteMode == Upscale.Overwrite.No)
                    outPath = Path.Combine(outDir.Text.Trim(), filename + "-" + Upscale.GetLastModelName() + ext);
                else
                    outPath = Path.Combine(outDir.Text.Trim(), Path.GetFileName(currentInPath));
            }
            catch (Exception e)
            {
                Logger.Log($"Path Combine Error: {e.Message} - Path.Combine(outDir.Text.Trim() = {outDir.Text.Trim()}, filename = {filename} + \"-\" + Program.lastModelName = {Program.lastModelName} + ext = {ext}");
            }
            
            outPath = Path.ChangeExtension(outPath, outputFormat.ToString().ToLower());
            Print("Moving output video to " + outPath + "...");
            try
            {
                if (File.Exists(outPath))
                    File.Delete(outPath);
                File.Move(path, outPath);
            }
            catch (Exception e)
            {
                Logger.ErrorMessage("Failed to move video file to output folder.\nMake sure no other programs are accessing files in that folder.\n", e);
            }
        }

        static void RenameOutFiles()
        {
            string[] frames = IOUtils.GetCompatibleFiles(Paths.framesOutPath, false);
            foreach (string frame in frames)
            {
                if (frame.Contains("-"))
                {
                    string filename = Path.GetFileName(frame);
                    string newFilename = Path.GetFileNameWithoutExtension(frame).Split('-')[0];
                    string newPath = Path.Combine(frame.GetParentDir(), newFilename + Path.GetExtension(frame)).Replace(".png.png", ".png");
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
