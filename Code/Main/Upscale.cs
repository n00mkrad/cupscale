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
        public static Implementations.Implementation currentAi = Implementations.Imps.esrganPytorch;

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
                IOUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + GetLastModelName(), "");
            }
            else
            {
                Logger.Log("Overwrite is off - keeping suffix.");
            }

            await IOUtils.CopyDir(Paths.imgOutPath, path);
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

        public static string FilenamePostprocess(string file)
        {
            try
            {
                string newFilename = file;
                string pathNoExt = Path.ChangeExtension(file, null);
                string ext = Path.GetExtension(file);

                newFilename = pathNoExt + "-" + GetLastModelName() + ext;
                Logger.Log($"FilenamePostprocess: Moving {file} => {newFilename}");
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

        public static string GetOutputImg ()
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
