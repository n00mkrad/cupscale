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
    class BatchUpscaleUI
    {

        static TextBox outDir;
        static TextBox fileList;
        static Label titleLabel;

        static string currentInDir;
        static string currentParentDir;
        static string[] currentInFiles;

        static bool multiImgMode = false;

        public static Stopwatch sw = new Stopwatch();

        public static void Init (TextBox outDirBox, TextBox fileListBox, Label mainLabel)
        {
            outDir = outDirBox;
            fileList = fileListBox;
            titleLabel = mainLabel;
        }

        public static void LoadDir (string path)
        {
            multiImgMode = false;
            outDir.Text = path;
            currentInDir = path.Trim();
            currentParentDir = path.Trim();
            currentInFiles = null;
            Program.lastDirPath = currentInDir;
            string[] files = Directory.GetFiles(currentInDir, "*", SearchOption.AllDirectories).Where(file => IOUtils.compatibleExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))).ToArray();
            FillFileList(files, true);
            TabSelected();
        }

        public static void TabSelected ()
        {
            if (!outDir.Visible)
                return;
            if (string.IsNullOrWhiteSpace(currentInDir))
            {
                Program.mainForm.SetButtonText("Upscale Images");
                return;
            }
            int compatFilesAmount = IOUtils.GetAmountOfCompatibleFiles(currentInDir, true);
            titleLabel.Text = "Loaded " + currentInDir.Wrap() + " - Found " + compatFilesAmount + " compatible files.";
            Program.mainForm.SetButtonText("Upscale " + compatFilesAmount + " Images");
        }

        public static void LoadImages(string[] imgs)
        {
            multiImgMode = true;
            outDir.Text = imgs[0].GetParentDir();
            currentInDir = Paths.imgInPath;
            currentParentDir = imgs[0].GetParentDir();
            currentInFiles = imgs;
            Program.lastDirPath = outDir.Text;
            FillFileList(imgs, false);
        }

        public static async Task CopyImages(string[] imgs, int targetAmount = 0)
        {
            IOUtils.ClearDir(Paths.imgInPath);

            int i = 0;
            foreach (string img in imgs)
            {
                if(IOUtils.compatibleExtensions.Contains(Path.GetExtension(img).ToLower()) && File.Exists(img))
                {
                    File.Copy(img, Path.Combine(Paths.imgInPath, Path.GetFileName(img)));
                    i++;
                    float prog = -1f;
                    if (targetAmount > 0)
                        prog = ((float)i / targetAmount) * 100f;
                    if (i % 20 == 0) Program.mainForm.SetProgress(prog, $"Copied {i} images...");
                }
                await Task.Delay(1);
            }
        }

        static void FillFileList (string[] files, bool relativePath)
        {
            fileList.Clear();
            string text = "";

            foreach (string file in files)
            {
                if (relativePath)
                {
                    string relPath = file.Replace(@"\", "/").Replace(currentParentDir.Replace(@"\", "/"), "");
                    text = text + "Root" + relPath + Environment.NewLine;
                }
                else
                {
                    text = text + file + Environment.NewLine;
                }
            }

            fileList.AppendText(text);
        }

        public static async Task Run (bool preprocess, bool postProcess = true, string overrideOutDir = "")
        {
            bool useNcnn = (Config.Get("cudaFallback").GetInt() == 2 || Config.Get("cudaFallback").GetInt() == 3);
            bool useCpu = (Config.Get("cudaFallback").GetInt() == 1);

            string imgOutDir = outDir.Text.Trim();
            if (!string.IsNullOrWhiteSpace(overrideOutDir)) imgOutDir = overrideOutDir;

            if (useNcnn && !Program.mainForm.HasValidNcnnModelSelection())
            {
                Program.ShowMessage("Invalid model selection - NCNN does not support interpolation or chaining.", "Error");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentInDir))
            {
                Program.ShowMessage("No directory loaded.", "Error");
                return;
            }
            if (!IOUtils.HasEnoughDiskSpace(IOUtils.GetAppDataDir(), 2.0f))
            {
                Program.ShowMessage($"Not enough disk space on {IOUtils.GetAppDataDir().Substring(0, 3)} to store temporary files!", "Error");
                return;
            }
            Upscale.currentMode = Upscale.UpscaleMode.Batch;
            Program.mainForm.SetBusy(true);
            Program.mainForm.SetProgress(2f, "Loading images...");
            await Task.Delay(20);
            Directory.CreateDirectory(imgOutDir);
            await CopyCompatibleImagesToTemp();
            Program.mainForm.SetProgress(3f, "Pre-Processing...");
            if (preprocess)
                await ImageProcessing.PreProcessImages(Paths.imgInPath, !bool.Parse(Config.Get("alpha")));
            else
                IOUtils.AppendToFilenames(Paths.imgInPath, ".png");
            ModelData mdl = Upscale.GetModelData();
            GetProgress(Paths.imgOutPath, IOUtils.GetAmountOfFiles(Paths.imgInPath, true));

            if(postProcess)
                PostProcessingQueue.Start(imgOutDir);

            List<Task> tasks = new List<Task>();
            ESRGAN.Backend backend = ESRGAN.Backend.CUDA;
            if (useCpu) backend = ESRGAN.Backend.CPU;
            if (useNcnn) backend = ESRGAN.Backend.NCNN;
            tasks.Add(ESRGAN.DoUpscale(Paths.imgInPath, Paths.imgOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), ESRGAN.PreviewMode.None, backend, false));
            if (postProcess)
            {
                tasks.Add(PostProcessingQueue.Update());
                tasks.Add(PostProcessingQueue.ProcessQueue());
            }
            sw.Restart();
            await Task.WhenAll(tasks);

            Program.mainForm.SetProgress(0, $"Done - Upscaling took {(sw.ElapsedMilliseconds / 1000f).ToString("0")}s");
            Program.mainForm.SetBusy(false);
        }

        public static int upscaledImages = 0;

        public static async void GetProgress (string outdir, int target)
        {
            upscaledImages = 0;
            while (Program.busy)
            {
                if (Directory.Exists(outdir))
                {
                    float percentage = (float)upscaledImages / target;
                    percentage = percentage * 100f;
                    if (percentage >= 100f)
                        break;
                    if(upscaledImages > 0)
                        Program.mainForm.SetProgress((int)Math.Round(percentage), "Upscaled " + upscaledImages + "/" + target + " images");
                }
                await Task.Delay(500);
            }
            Program.mainForm.SetProgress(0);
        }

        static async Task CopyCompatibleImagesToTemp(bool move = false)
        {
            IOUtils.ClearDir(Paths.imgOutPath);

            Logger.Log("currentInDir: " + currentInDir + ", imgInPath: " + Paths.imgInPath);
            if (currentInDir == Paths.imgInPath)    // Skip if we are directly upscaling the img-in folder
                return;

            Logger.Log("Clearing imgInPath");

            IOUtils.ClearDir(Paths.imgInPath);
            if (multiImgMode)
            {
                await CopyImages(currentInFiles);
            }
            else
            {
                string[] files = IOUtils.GetCompatibleFiles(currentInDir, true);
                await CopyImages(files, files.Length);
            }
        }
    }
}
