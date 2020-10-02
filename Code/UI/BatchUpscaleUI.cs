using Cupscale.Cupscale;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.OS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.UI
{
    class BatchUpscaleUI
    {

        static TextBox outDir;
        static TextBox fileList;

        static string currentInDir;
        static string currentParentDir;
        static string[] currentInFiles;

        static bool multiImgMode = false;

        public static void Init (TextBox outDirBox, TextBox fileListBox)
        {
            outDir = outDirBox;
            fileList = fileListBox;
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

        public static async Task CopyDroppedImages (string[] imgs)
        {
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            foreach (string img in imgs)
            {
                if(IOUtils.compatibleExtensions.Contains(Path.GetExtension(img).ToLower()) && File.Exists(img))
                    File.Copy(img, Path.Combine(Paths.imgInPath, Path.GetFileName(img)));
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

        public static async Task Run ()
        {
            if (string.IsNullOrWhiteSpace(currentInDir))
            {
                MessageBox.Show("No directory loaded.", "Error");
                return;
            }
            Upscale.currentMode = Upscale.UpscaleMode.Batch;
            Program.mainForm.SetBusy(true);
            Directory.CreateDirectory(outDir.Text.Trim());
            await CopyCompatibleImagesToTemp();
            Program.mainForm.SetProgress(0f, "Pre-Processing...");
            await ImageProcessing.PreProcessImages(Paths.imgInPath, !bool.Parse(Config.Get("alpha")));
            ModelData mdl = Upscale.GetModelData();
            GetProgress(Paths.imgOutPath, IOUtils.GetAmountOfFiles(Paths.imgInPath, true));

            PostProcessingQueue.Start(outDir.Text.Trim());

            List<Task> tasks = new List<Task>();
            tasks.Add(ESRGAN.DoUpscale(Paths.imgInPath, Paths.imgOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), ESRGAN.PreviewMode.None, true, false));
            tasks.Add(PostProcessingQueue.Update());
            tasks.Add(PostProcessingQueue.ProcessQueue());

            await Task.WhenAll(tasks);

            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            IOUtils.DeleteContentsOfDir(Paths.imgOutPath);

            Program.mainForm.SetProgress(0f, "Done.");
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
                    //int count = PostProcessingQueue.processedFiles.Count;
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
            IOUtils.DeleteContentsOfDir(Paths.imgOutPath);
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            if (multiImgMode)
            {
                await CopyDroppedImages(currentInFiles);
            }
            else
            {
                IOUtils.Copy(currentInDir, Paths.imgInPath, "*", move, true);
            }
        }
    }
}
