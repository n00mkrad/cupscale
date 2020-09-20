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
        public static async Task CopyImagesTo(string path)
        {
            if (overwrite.SelectedIndex == 1)
            {
                Logger.Log("Overwrite mode - removing suffix from filenames");
                IOUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + Program.lastModelName, "");
            }
            IOUtils.Copy(Paths.imgOutPath, path);
            await Task.Delay(1);
        }

        public static async Task AddModelSuffix(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)     // Remove PNG extensions
            {
                string pathNoExt = Path.ChangeExtension(file.FullName, null);
                Logger.Log("pathNoExt: " + pathNoExt);
                string ext = Path.GetExtension(file.FullName);
                Logger.Log("ext: " + ext);
                File.Move(file.FullName, pathNoExt + "-" + Program.lastModelName.Replace(":", ".").Replace(">>", "+") + ext);
                await Task.Delay(1);
            }
        }

        public static ModelData GetModelData()
        {
            ModelData mdl = new ModelData();

            if (currentMode == Mode.Single)
            {
                string mdl1 = Program.currentModel1;
                if (string.IsNullOrWhiteSpace(mdl1)) return mdl;
                mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
            }
            if (currentMode == Mode.Interp)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, interpValue);
            }
            if (currentMode == Mode.Chain)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return mdl;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
            }

            return mdl;
        }

        public static async Task Preprocessing (string path, bool appendExt = false)
        {
            Logger.Log("Preprocessing: " + path);
            bool fillAlpha = !bool.Parse(Config.Get("alpha"));
            await ImageProcessing.ConvertImages(path, ImageProcessing.Format.PngFast, fillAlpha);
        }

        public static async Task Postprocessing()
        {
            Program.mainForm.SetProgress(100f, "Postprocessing...");
            await Program.PutTaskDelay();
            Logger.Log("Postprocessing - outputFormat.SelectedIndex = " + outputFormat.SelectedIndex);
            if (outputFormat.SelectedIndex == 0)
                ImageProcessing.ChangeOutputExtensions("png");
            if (outputFormat.SelectedIndex == 1)
                await ImageProcessing.ConvertImagesToOriginalFormat();
            if (outputFormat.SelectedIndex == 2)
                await ImageProcessing.ConvertImages(Paths.imgOutPath, ImageProcessing.Format.JpegHigh);
            if (outputFormat.SelectedIndex == 3)
                await ImageProcessing.ConvertImages(Paths.imgOutPath, ImageProcessing.Format.JpegMed);
            if (outputFormat.SelectedIndex == 4)
                await ImageProcessing.ConvertImages(Paths.imgOutPath, ImageProcessing.Format.WeppyHigh);
            if (outputFormat.SelectedIndex == 5)
                await ImageProcessing.ConvertImages(Paths.imgOutPath, ImageProcessing.Format.WeppyLow);
        }

        public static async Task FilenamePostprocessing ()
        {
            await AddModelSuffix(Paths.imgOutPath);
            IOUtils.DeleteFilesWithoutExt(Paths.imgOutPath, true);
            IOUtils.RenameExtensions(Paths.imgOutPath, "jpg", Config.Get("jpegExtension"));
            await Program.PutTaskDelay();
        }

        /*
        public static string GetMdl(Button btn)
        {
            string mdl = btn.Text.Trim();
            EsrganData.ReloadModelList();
            if (!EsrganData.models.Contains(mdl))
            {
                MessageBox.Show("Model file not found!", "Error");
                Program.mainForm.SetProgress(0);
                Program.mainForm.SetBusy(false);
                return "";
            }
            return mdl;
        }
        */
    }
}
