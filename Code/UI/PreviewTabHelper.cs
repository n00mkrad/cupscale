using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Numerics;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.IO;
using Cupscale.OS;
using Cyotek.Windows.Forms;
using shellUpscaler;

namespace Cupscale.UI
{
    internal class PreviewTabHelper
    {
        public enum Mode { Single, Interp, Chain, Advanced }
        public static Mode currentMode;
        public static ImageBox previewImg;

        private static ComboBox model1;
        private static ComboBox model2;

        public static int interpValue;

        private static ComboBox outputFormat;
        private static ComboBox overwrite;

        public static Image currentOriginal;
        public static Image currentOutput;

        public static int currentScale = 1;

        public static void Init(ImageBox imgBox, ComboBox model1Box, ComboBox model2Box, ComboBox formatBox, ComboBox overwriteBox)
        {
            previewImg = imgBox;
            model1 = model1Box;
            model2 = model2Box;
            outputFormat = formatBox;
            overwrite = overwriteBox;
        }

        public static async void UpscaleImage()
        {
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            IOUtils.DeleteContentsOfDir(Paths.imgOutPath);
            Program.mainForm.SetPreviewProgress(3f, "Preprocessing...");
            if (!CopyImage())  // Try to copy/move image to input folder, return if failed
            {
                Cancel("I/O Error");
                return;
            }
            UpscaleProcessing.ConvertImages(UpscaleProcessing.Format.PngFast, !Config.GetBool("alpha"), true, true);
            ModelData mdl = new ModelData();

            if (currentMode == Mode.Single)
            {
                string mdl1 = GetMdl(model1);
                if (string.IsNullOrWhiteSpace(mdl1)) return;
                mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
            }
            if (currentMode == Mode.Interp)
            {
                string mdl1 = GetMdl(model1);
                string mdl2 = GetMdl(model2);
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, 80);
            }
            if (currentMode == Mode.Chain)
            {
                string mdl1 = GetMdl(model1);
                string mdl2 = GetMdl(model2);
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
            }
            await ESRGAN.UpscaleBasic(Paths.imgInPath, Paths.imgOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), ESRGAN.PreviewMode.None);
            await Postprocessing();
            await AddModelSuffix(Paths.imgOutPath);
            await CopyImagesToOriginalLocation();
            Program.mainForm.SetPreviewProgress(0, "Done.");
        }

        static void Cancel(string reason = "")
        {
            if (string.IsNullOrWhiteSpace(reason))
                Program.mainForm.SetPreviewProgress(0f, "Cancelled.");
            else
                Program.mainForm.SetPreviewProgress(0f, "Cancelled: " + reason);
            string inputImgPath = Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename));
            if (overwrite.SelectedIndex == 1 && File.Exists(inputImgPath) && !File.Exists(Program.lastFilename))    // Copy image back if overwrite mode was on
                File.Move(inputImgPath, Program.lastFilename);
        }

        static bool CopyImage()
        {
            try
            {
                if (overwrite.SelectedIndex == 1)
                    File.Move(Program.lastFilename, Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename)));
                else
                    File.Copy(Program.lastFilename, Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename)));
            }
            catch (Exception e)
            {
                MessageBox.Show("Error trying to copy/move file: \n\n" + e.Message, "Error");
                return false;
            }
            return true;
        }

        static async Task Postprocessing()
        {
            Program.mainForm.SetPreviewProgress(100f, "Postprocessing...");
            await Program.PutTaskDelay();
            Logger.Log("Postprocessing - outputFormat.SelectedIndex = " + outputFormat.SelectedIndex);
            if (outputFormat.SelectedIndex == 0)
                UpscaleProcessing.ChangeOutputExtensions("png");
            if (outputFormat.SelectedIndex == 1)
                UpscaleProcessing.ConvertImagesToOriginalFormat();
            if (outputFormat.SelectedIndex == 2)
                UpscaleProcessing.ConvertImages(UpscaleProcessing.Format.JpegHigh);
            if (outputFormat.SelectedIndex == 3)
                UpscaleProcessing.ConvertImages(UpscaleProcessing.Format.JpegMed);
            if (outputFormat.SelectedIndex == 4)
                UpscaleProcessing.ConvertImages(UpscaleProcessing.Format.WeppyHigh);
            if (outputFormat.SelectedIndex == 5)
                UpscaleProcessing.ConvertImages(UpscaleProcessing.Format.WeppyLow);
        }

        static async Task AddModelSuffix(string path)
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

        static async Task CopyImagesToOriginalLocation()
        {
            if (overwrite.SelectedIndex == 1)
            {
                Logger.Log("Overwrite mode - removing suffix from filenames");
                IOUtils.ReplaceInFilenamesDir(Paths.imgOutPath, "-" + Program.lastModelName, "");
            }
            IOUtils.Copy(Paths.imgOutPath, Path.GetDirectoryName(Program.lastFilename));
            await Task.Delay(1);
        }

        public static async void UpscalePreview(bool fullImage = false)
        {
            Program.mainForm.SetPreviewProgress(3f, "Preparing...");
            ResetCachedImages();
            IOUtils.DeleteContentsOfDir(Paths.previewPath);
            IOUtils.DeleteContentsOfDir(Paths.previewOutPath);
            ESRGAN.PreviewMode prevMode = ESRGAN.PreviewMode.Cutout;
            if (fullImage)
            {
                prevMode = ESRGAN.PreviewMode.FullImage;
                if (!IOUtils.TryCopy(Program.lastFilename, Path.Combine(Paths.previewPath, "preview.png"), true)) return;
            }
            else
            {
                SaveCurrentCutout();
            }
            if (currentMode == Mode.Single)
            {
                string mdl1 = GetMdl(model1);
                if (string.IsNullOrWhiteSpace(mdl1)) return;
                ModelData mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
                await ESRGAN.UpscaleBasic(Paths.previewPath, Paths.previewOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), prevMode);
            }
            if (currentMode == Mode.Interp)
            {
                string mdl1 = GetMdl(model1);
                string mdl2 = GetMdl(model2);
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                ModelData mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, 80);
                await ESRGAN.UpscaleBasic(Paths.previewPath, Paths.previewOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), prevMode);
            }
            if (currentMode == Mode.Chain)
            {
                string mdl1 = GetMdl(model1);
                string mdl2 = GetMdl(model2);
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                ModelData mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
                await ESRGAN.UpscaleBasic(Paths.previewPath, Paths.previewOutPath, mdl, Config.Get("tilesize"), bool.Parse(Config.Get("alpha")), prevMode);
            }
        }

        static string GetMdl(ComboBox box)
        {
            string mdl = box.Text.Trim();
            EsrganData.ReloadModelList();
            if (!EsrganData.models.Contains(mdl))
            {
                MessageBox.Show("Model file not found!", "Error");
                Program.mainForm.SetPreviewProgress(0);
                return "";
            }
            return mdl;
        }

        public static void SaveCurrentCutout()
        {
            UIHelpers.ReplaceImageAtSameScale(previewImg, IOUtils.GetImage(Program.lastFilename));
            string path = Path.Combine(Paths.previewPath, "preview.png");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            GetCurrentRegion().Save(path);
        }

        public static Bitmap GetCurrentRegion()     // thx ieu
        {
            RectangleF sourceImageRegion = previewImg.GetSourceImageRegion();
            int num = (int)Math.Round(sourceImageRegion.Width);
            int num2 = (int)Math.Round(sourceImageRegion.Height);
            double zoomFactor = previewImg.ZoomFactor;
            int num3 = (int)Math.Round(SystemInformation.VerticalScrollBarWidth / zoomFactor);
            int num4 = (int)Math.Round(SystemInformation.HorizontalScrollBarHeight / zoomFactor);
            int num5 = (int)Math.Round(sourceImageRegion.Width * zoomFactor);
            int num6 = (int)Math.Round(sourceImageRegion.Height * zoomFactor);
            Size size = previewImg.GetInsideViewPort().Size;
            Logger.Log("Saving current region to bitmap. Offset: " + previewImg.AutoScrollPosition.X + "x" + previewImg.AutoScrollPosition.Y);
            PreviewMerger.offsetX = (float)previewImg.AutoScrollPosition.X / (float)previewImg.ZoomFactor;
            PreviewMerger.offsetY = (float)previewImg.AutoScrollPosition.Y / (float)previewImg.ZoomFactor;
            if (num5 <= size.Width)
            {
                num3 = 0;
            }
            if (num6 <= size.Height)
            {
                num4 = 0;
            }
            num += num3;
            num2 += num4;
            sourceImageRegion.Width = num;
            sourceImageRegion.Height = num2;
            Bitmap bitmap = new Bitmap(num, num2);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.DrawImage(previewImg.Image, new Rectangle(0, 0, num, num2), sourceImageRegion, GraphicsUnit.Pixel);
            }
            return bitmap;
        }

        public static SizeF GetCutoutSize()
        {
            SizeF cutoutSize = previewImg.GetSourceImageRegion().Size;
            cutoutSize.Width = (int)Math.Round(cutoutSize.Width);
            cutoutSize.Height = (int)Math.Round(cutoutSize.Height);
            return cutoutSize;
        }

        public static void ResetCachedImages()
        {
            currentOriginal = null;
            currentOutput = null;
        }

        public static void UpdatePreviewLabels(Label zoom, Label size, Label cutout)
        {
            int currScale = currentScale;
            int cutoutW = (int)GetCutoutSize().Width;
            int cutoutH = (int)GetCutoutSize().Height;
            zoom.Text = "Zoom: " + previewImg.Zoom + "% (Original: " + previewImg.Zoom * currScale + "%)";
            size.Text = "Size: " + previewImg.Image.Width + "x" + previewImg.Image.Height + " (Original: " + previewImg.Image.Width / currScale + "x" + previewImg.Image.Height / currScale + ")";
            cutout.Text = "Cutout: " + cutoutW + "x" + cutoutH + " (Original: " + cutoutW / currScale + "x" + cutoutH / currScale + ")";// + "% - Unscaled Size: " + previewImg.Image.Size * currScale + "%";
        }

        public static bool DroppedImageIsValid(string path)
        {
            try
            {
                Image img = IOUtils.GetImage(path);
                if (img.Width > 4096 || img.Height > 4096)
                {
                    MessageBox.Show("Image is too big for the preview!\nPlease use images with less than 4096 pixels on either side.", "Error");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to open image:\n\n" + e.Message, "Error");
                return false;
            }
            return true;
        }
    }
}
