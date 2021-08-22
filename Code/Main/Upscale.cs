using Cupscale.ImageUtils;
using Cupscale.Implementations;
using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
//using static Cupscale.UI.PreviewUi;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Cupscale.Main
{
    class Upscale
    {
        public static Implementations.Implementation currentAi = Implementations.Imps.esrganPytorch;

        public enum UpscaleMode { Preview, Single, Batch, Composition }
        public static UpscaleMode currentMode = UpscaleMode.Preview;
        public enum ImgExportMode { PNG, SameAsSource, JPEG, WEBP, BMP, TGA, DDS, GIF }
        public enum VidExportMode { MP4, GIF, SameAsSource }
        public enum Filter { Mitchell, Bicubic, Nearest }
        public enum ScaleMode { Percent, PixelsHeight, PixelsWidth, PixelsShorterSide, PixelsLongerSide }
        public enum Overwrite { No, Yes, }
        public static Overwrite overwriteMode = Overwrite.No;

        public static async Task Run(string inpath, string outpath, ModelData mdl, bool cacheSplitDepth, bool alpha, PreviewUi.PreviewMode mode, bool showTileProgress = true)
        {
            Program.canceled = false;      // Reset cancel flag

            try
            {
                if (currentAi == Imps.esrganPytorch)
                    await EsrganPytorch.Run(inpath, outpath, mdl, cacheSplitDepth, alpha, showTileProgress);

                if (currentAi == Imps.esrganNcnn)
                    await EsrganNcnn.Run(inpath, outpath, mdl);

                if (currentAi == Imps.realEsrganNcnn)
                    await RealEsrganNcnn.Run(inpath, outpath, mdl);

                if (Program.canceled) return;

                if (mode == PreviewUi.PreviewMode.Cutout)
                {
                    await PreviewUi.ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    PreviewMerger.Merge();
                    Program.mainForm.SetHasPreview(true);
                }

                if (mode == PreviewUi.PreviewMode.FullImage)
                {
                    await PreviewUi.ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    Image outImg = ImgUtils.GetImage(Directory.GetFiles(Paths.previewOutPath, "preview.*", SearchOption.AllDirectories)[0]);
                    Image inputImg = ImgUtils.GetImage(Paths.tempImgPath);
                    PreviewUi.previewImg.Image = outImg;
                    PreviewUi.currentOriginal = inputImg;
                    PreviewUi.currentOutput = outImg;
                    PreviewUi.currentScale = ImgUtils.GetScaleFloat(inputImg, outImg);
                    PreviewUi.previewImg.ZoomToFit();
                    Program.mainForm.SetHasPreview(true);
                    //Program.mainForm.SetProgress(0f, "Done.");
                }

            }
            catch (Exception e)
            {
                Program.mainForm.SetProgress(0f, "Cancelled.");

                if (Program.canceled)
                    return;

                if (e.Message.Contains("No such file"))
                    Program.ShowMessage("An error occured during upscaling.\nThe upscale process seems to have exited before completion!", "Error");
                else
                    Program.ShowMessage("An error occured during upscaling.", "Error");

                Logger.Log("[ESRGAN] Upscaling Error: " + e.Message + "\n" + e.StackTrace);
            }

        }

        public static async Task CopyImagesTo(string path)
        {
            Program.lastOutputDir = path;
            Program.mainForm.AfterFirstUpscale();

            if (overwriteMode == Overwrite.Yes)
            {
                Logger.Log("Overwrite mode - removing suffix from filenames");
                IoUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + GetLastModelName(), "");
            }
            else
            {
                Logger.Log("Overwrite is off - keeping suffix.");
            }

            await IoUtils.CopyDir(Paths.imgOutPath, path);
            await Task.Delay(1);
            IoUtils.ClearDir(Paths.imgInPath);
            IoUtils.ClearDir(Paths.imgOutPath);
        }

        public static async Task AddModelSuffix(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)     // Remove PNG extensions
            {
                string pathNoExt = Path.ChangeExtension(file.FullName, null);
                string ext = Path.GetExtension(file.FullName);
                File.Move(file.FullName, pathNoExt + "-" + GetLastModelName() + ext);
                await Task.Delay(1);
            }
        }

        public static string GetLastModelName()
        {
            return Program.lastModelName.Replace(":", ".").Replace(">>", "+");
        }

        public static ModelData GetModelData()
        {
            ModelData mdl = new ModelData();

            if (PreviewUi.currentMode == PreviewUi.MdlMode.Single)
            {
                string mdl1 = Program.currentModel1;
                if (string.IsNullOrWhiteSpace(mdl1)) return mdl;
                mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
            }

            if (PreviewUi.currentMode == PreviewUi.MdlMode.Interp)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, PreviewUi.interpValue);
            }

            if (PreviewUi.currentMode == PreviewUi.MdlMode.Chain)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
            }

            if (PreviewUi.currentMode == PreviewUi.MdlMode.Advanced)
            {
                mdl = new ModelData(null, null, ModelData.ModelMode.Advanced);
            }

            return mdl;
        }

        public static string FilenamePostprocess(string file)
        {
            if (Program.canceled) return null;

            try
            {
                string newFilename = file;
                string pathNoExt = Path.ChangeExtension(file, null);
                string ext = Path.GetExtension(file);

                newFilename = pathNoExt + "-" + GetLastModelName() + ext;
                Logger.Log($"FilenamePostprocess: Moving {file} => {newFilename}");
                File.Move(file, newFilename);
                newFilename = IoUtils.RenameExtension(newFilename, "jpg", Config.Get("jpegExtension"));

                return newFilename;
            }
            catch (Exception e)
            {
                Logger.ErrorMessage("Error during FilenamePostprocess(): ", e);
                return null;
            }
        }

        public static string GetOutputImg()
        {
            string outImg = "";

            try
            {
                outImg = Directory.GetFiles(Paths.imgOutPath, "*.png", SearchOption.AllDirectories)[0];
            }
            catch
            {
                try
                {
                    outImg = Directory.GetFiles(Paths.imgOutPath, "*.tmp", SearchOption.AllDirectories)[0];
                }
                catch (Exception e)
                {
                    Logger.ErrorMessage("Error: Can't find upscaled output image! This probably means the AI implementation failed to run correctly.", e);
                }
            }

            return outImg;
        }

        
    }
}
