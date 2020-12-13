using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static Cupscale.UI.PreviewUI;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Cupscale.Main
{
    class Upscale
    {
        public enum UpscaleMode { Preview, Single, Batch, Composition }
        public static UpscaleMode currentMode = UpscaleMode.Preview;
        public enum ImgExportMode { PNG, SameAsSource, JPEG, WEBP, BMP, TGA, DDS, GIF }
        public enum VidExportMode { MP4, GIF, SameAsSource }
        public enum Filter { Mitchell, Bicubic, NearestNeighbor }
        public enum ScaleMode { Percent, PixelsHeight, PixelsWidth, PixelsShorterSide, PixelsLongerSide }
        public enum Overwrite { No, Yes, }
        public static Overwrite overwriteMode = Overwrite.No;

    public static async Task CopyImagesTo(string path)
        {
            Program.lastOutputDir = path;
            Program.mainForm.AfterFirstUpscale();
            if (overwriteMode == Overwrite.Yes)
            {
                Logger.Log("Overwrite mode - removing suffix from filenames");
                IOUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + Program.lastModelName, "");
                IOUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + GetLastModelName(), "");
            }
            else
            {
                Logger.Log("Overwrite is off - keeping suffix.");
            }
            IOUtils.Copy(Paths.imgOutPath, path);
            await Task.Delay(1);
            IOUtils.ClearDir(Paths.imgInPath);
            IOUtils.ClearDir(Paths.imgOutPath);
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

        public static string GetLastModelName ()
        {
            return Program.lastModelName.Replace(":", ".").Replace(">>", "+");
        }

        public static ModelData GetModelData()
        {
            ModelData mdl = new ModelData();

            if (PreviewUI.currentMode == Mode.Single)
            {
                string mdl1 = Program.currentModel1;
                if (string.IsNullOrWhiteSpace(mdl1)) return mdl;
                mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
            }
            if (PreviewUI.currentMode == Mode.Interp)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, interpValue);
            }
            if (PreviewUI.currentMode == Mode.Chain)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
            }
            if (PreviewUI.currentMode == Mode.Advanced)
            {
                mdl = new ModelData(null, null, ModelData.ModelMode.Advanced);
            }

            return mdl;
        }

        public static async Task PostprocessingSingle (string path, bool dontResize = false, int retryCount = 10)
        {
            string newPath = "";
            if (Path.GetExtension(path) != ".tmp")
                newPath = path.Substring(0, path.Length - 8);
            else
                newPath = path.Substring(0, path.Length - 4);

            try
            {
                File.Move(path, newPath);
            }
            catch (Exception e)     // An I/O error can appear if the file is still locked by python (?)
            {
                Logger.Log("Failed to move/rename! " + e.Message + "\n" + e.StackTrace);
                if(retryCount > 0)
                {
                    await Task.Delay(200);      // Wait 200ms and retry up to 10 times
                    int newRetryCount = retryCount - 1;
                    Logger.Log("Retrying - " + newRetryCount + " attempts left.");
                    PostprocessingSingle(path, dontResize, newRetryCount);
                }
                else
                {
                    Logger.ErrorMessage($"Failed to rename {Path.GetFileName(path)} and ran out of retries!", e);
                }
                return;
            }

            path = newPath;

            if (outputFormat.Text == ImgExportMode.PNG.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Png50, dontResize);
            if (outputFormat.Text == ImgExportMode.SameAsSource.ToStringTitleCase())
                await ImageProcessing.ConvertImageToOriginalFormat(path, true, false, dontResize);
            if (outputFormat.Text == ImgExportMode.JPEG.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Jpeg, dontResize);
            if (outputFormat.Text == ImgExportMode.WEBP.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Weppy, dontResize);
            if (outputFormat.Text == ImgExportMode.BMP.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.BMP, dontResize);
            if (outputFormat.Text == ImgExportMode.TGA.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.TGA, dontResize);
            if (outputFormat.Text == ImgExportMode.DDS.ToStringTitleCase())
                await ImageProcessing.PostProcessDDS(path);
            if (outputFormat.Text == ImgExportMode.GIF.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.GIF, dontResize);
        }

        public static string FilenamePostprocess(string file)
        {
            try
            {
                string newFilename = file;
                string pathNoExt = Path.ChangeExtension(file, null);
                string ext = Path.GetExtension(file);

                newFilename = pathNoExt + "-" + GetLastModelName() + ext;
                File.Move(file, newFilename);
                newFilename = IOUtils.RenameExtension(newFilename, "jpg", Config.Get("jpegExtension"));

                return newFilename;
            }
            catch (Exception e)
            {
                Logger.ErrorMessage("Error during FilenamePostprocess(): ", e);
                return null;
            }
        }
    }
}
