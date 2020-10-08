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
using static Cupscale.UI.MainUIHelper;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Cupscale.Main
{
    class Upscale
    {
        public enum UpscaleMode { Preview, Single, Batch }
        public static UpscaleMode currentMode = UpscaleMode.Preview;
        public enum ExportFormats { PNG, SameAsSource, JPEG, WEBP, BMP, TGA, DDS }
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
            }
            else
            {
                Logger.Log("Overwrite is off - keeping suffix.");
            }
            IOUtils.Copy(Paths.imgOutPath, path);
            await Task.Delay(1);
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            IOUtils.DeleteContentsOfDir(Paths.imgOutPath);
        }

        public static async Task AddModelSuffix(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)     // Remove PNG extensions
            {
                string pathNoExt = Path.ChangeExtension(file.FullName, null);
                string ext = Path.GetExtension(file.FullName);
                File.Move(file.FullName, pathNoExt + "-" + Program.lastModelName.Replace(":", ".").Replace(">>", "+") + ext);
                await Task.Delay(1);
            }
        }

        public static ModelData GetModelData()
        {
            ModelData mdl = new ModelData();

            if (MainUIHelper.currentMode == Mode.Single)
            {
                string mdl1 = Program.currentModel1;
                if (string.IsNullOrWhiteSpace(mdl1)) return mdl;
                mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
            }
            if (MainUIHelper.currentMode == Mode.Interp)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, interpValue);
            }
            if (MainUIHelper.currentMode == Mode.Chain)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
            }
            if (MainUIHelper.currentMode == Mode.Advanced)
            {
                mdl = new ModelData(null, null, ModelData.ModelMode.Advanced);
            }

            return mdl;
        }

        public static async Task PostprocessingSingle (string path, bool dontResize = false)
        {
            Logger.Log("PostprocessingSingle: " + path);
            string newPath = path.Substring(0, path.Length - 4);
            File.Move(path, newPath);
            path = newPath;
            Logger.Log("PostprocessingSingle New Path: " + path);

            if (outputFormat.Text == ExportFormats.PNG.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Png50, dontResize);
            if (outputFormat.Text == ExportFormats.SameAsSource.ToStringTitleCase())
                await ImageProcessing.ConvertImageToOriginalFormat(path, true, false, dontResize);
            if (outputFormat.Text == ExportFormats.JPEG.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Jpeg, dontResize);
            if (outputFormat.Text == ExportFormats.WEBP.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.Weppy, dontResize);
            if (outputFormat.Text == ExportFormats.BMP.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.BMP, dontResize);
            if (outputFormat.Text == ExportFormats.TGA.ToStringTitleCase())
                await ImageProcessing.PostProcessImage(path, ImageProcessing.Format.TGA, dontResize);
            if (outputFormat.Text == ExportFormats.DDS.ToStringTitleCase())
                await ImageProcessing.PostProcessDDS(path);
        }

        public static string FilenamePostprocess(string file)
        {
            try
            {
                string newFilename = file;

                string pathNoExt = Path.ChangeExtension(file, null);
                string ext = Path.GetExtension(file);

                newFilename = pathNoExt + "-" + Program.lastModelName.Replace(":", ".").Replace(">>", "+") + ext;

                File.Move(file, newFilename);
                newFilename = IOUtils.RenameExtension(newFilename, "jpg", Config.Get("jpegExtension"));

                return newFilename;
            }
            catch (Exception e)
            {
                Logger.LogErrorWithMessage("Error during FilenamePostprocess(): " + e.Message);
                return null;
            }
        }
    }
}
