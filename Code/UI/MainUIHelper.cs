using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.OS;
using Cyotek.Windows.Forms;
using HTAlt.WinForms;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale.UI
{
    internal class MainUIHelper
    {
        public enum Mode { Single, Interp, Chain, Advanced }
        public static Mode currentMode;
        public static ImageBox previewImg;

        public static Button model1;
        public static Button model2;

        public static int interpValue;

        public static ComboBox outputFormat;
        public static ComboBox overwrite;

        public static Image currentOriginal;
        public static Image currentOutput;

        public static float currentScale = 1;

        public static void Init(ImageBox imgBox, Button model1Btn, Button model2Btn, ComboBox formatBox, ComboBox overwriteBox)
        {
            previewImg = imgBox;
            model1 = model1Btn;
            model2 = model2Btn;
            outputFormat = formatBox;
            overwrite = overwriteBox;
        }

        public static string lastOutfile;

        public static async Task UpscaleImage()
        {
            Program.mainForm.SetBusy(true);
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            IOUtils.DeleteContentsOfDir(Paths.imgOutPath);
            Program.mainForm.SetProgress(3f, "Preprocessing...");
            string inImg = CopyImage();
            if (inImg == null)  // Try to copy/move image to input folder, return if failed
            {
                Cancel("I/O Error");
                return;
            }
            Upscale.currentMode = Upscale.UpscaleMode.Single;
            await ImageProcessing.PreProcessImage(inImg, !Config.GetBool("alpha"));
            ModelData mdl = Upscale.GetModelData();
            string outImg = null;
            try
            {
                await ESRGAN.Upscale(Paths.imgInPath, Paths.imgOutPath, mdl, Config.Get("tilesize"), Config.GetBool("alpha"), ESRGAN.PreviewMode.None, true);
                outImg = Directory.GetFiles(Paths.imgOutPath, "*.tmp", SearchOption.AllDirectories)[0];
                await Upscale.PostprocessingSingle(outImg, false);
                string outFilename = Upscale.FilenamePostprocess(lastOutfile);
                await Upscale.CopyImagesTo(Path.GetDirectoryName(Program.lastFilename));
            }
            catch (Exception e)
            {
                if (e.StackTrace.Contains("Index"))
                    MessageBox.Show("The upscale process seems to have exited before completion!", "Error");
                MessageBox.Show("An error occured during upscaling: \n\n" + e.Message, "Error");
                Logger.Log("Upscaling Error: " + e.Message + "\n" + e.StackTrace);
                Program.mainForm.SetProgress(0f, "Cancelled.");
            }
            Program.mainForm.SetProgress(0, "Done.");
            Program.mainForm.SetBusy(false);
        }

        static void Cancel(string reason = "")
        {
            if (string.IsNullOrWhiteSpace(reason))
                Program.mainForm.SetProgress(0f, "Cancelled.");
            else
                Program.mainForm.SetProgress(0f, "Cancelled: " + reason);
            string inputImgPath = Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename));
            if (overwrite.SelectedIndex == 1 && File.Exists(inputImgPath) && !File.Exists(Program.lastFilename))    // Copy image back if overwrite mode was on
                File.Move(inputImgPath, Program.lastFilename);
        }

        public static bool HasValidModelSelection()
        {
            bool valid = true;
            if (model1.Enabled && !File.Exists(Program.currentModel1))
                valid = false;
            if (model2.Enabled && !File.Exists(Program.currentModel2))
                valid = false;
            return valid;
        }

        static string CopyImage()
        {
            string outpath = Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename));
            try
            {
                //if (overwrite.SelectedIndex == 1)
                //    File.Move(Program.lastFilename, Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastFilename)));
                //else
                File.Copy(Program.lastFilename, outpath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error trying to copy/move file: \n\n" + e.Message, "Error");
                return null;
            }
            return outpath;
        }


        public static async void UpscalePreview(bool fullImage = false)
        {
            if (!HasValidModelSelection())
            {
                MessageBox.Show("Invalid model selection.\nMake sure you have selected a model and that the file still exists.", "Error");
                return;
            }
            Upscale.currentMode = Upscale.UpscaleMode.Preview;
            Program.mainForm.SetBusy(true);
            Program.mainForm.SetProgress(3f, "Preparing...");
            Program.mainForm.resetState = new Cupscale.PreviewState(previewImg.Image, previewImg.Zoom, previewImg.AutoScrollPosition);
            ResetCachedImages();
            IOUtils.DeleteContentsOfDir(Paths.imgInPath);
            IOUtils.DeleteContentsOfDir(Paths.previewPath);
            IOUtils.DeleteContentsOfDir(Paths.previewOutPath);
            ESRGAN.PreviewMode prevMode = ESRGAN.PreviewMode.Cutout;
            if (fullImage)
            {
                prevMode = ESRGAN.PreviewMode.FullImage;
                if (!IOUtils.TryCopy(Paths.tempImgPath, Path.Combine(Paths.previewPath, "preview.png"), true)) return;
            }
            else
            {
                SaveCurrentCutout();
            }
            await ImageProcessing.PreProcessImages(Paths.previewPath, !bool.Parse(Config.Get("alpha")));
            string tilesize = Config.Get("tilesize");
            bool alpha = bool.Parse(Config.Get("alpha"));
            if (currentMode == Mode.Single)
            {
                string mdl1 = Program.currentModel1;
                if (string.IsNullOrWhiteSpace(mdl1)) return;
                ModelData mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
                await ESRGAN.Upscale(Paths.previewPath, Paths.previewOutPath, mdl, tilesize, alpha, prevMode, false);
            }
            if (currentMode == Mode.Interp)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                ModelData mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, interpValue);
                await ESRGAN.Upscale(Paths.previewPath, Paths.previewOutPath, mdl, tilesize, alpha, prevMode, false);
            }
            if (currentMode == Mode.Chain)
            {
                string mdl1 = Program.currentModel1;
                string mdl2 = Program.currentModel2;
                if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                ModelData mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
                await ESRGAN.Upscale(Paths.previewPath, Paths.previewOutPath, mdl, tilesize, alpha, prevMode, false);
            }
            Program.mainForm.SetBusy(false);
        }

        public static void SaveCurrentCutout()
        {
            UIHelpers.ReplaceImageAtSameScale(previewImg, ImgUtils.GetImage(Paths.tempImgPath));
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
            float scale = currentScale;
            int cutoutW = (int)GetCutoutSize().Width;
            int cutoutH = (int)GetCutoutSize().Height;

            zoom.Text = "Zoom: " + previewImg.Zoom + "% (Original: " + (previewImg.Zoom * scale).RoundToInt() + "%)";
            size.Text = "Size: " + previewImg.Image.Width + "x" + previewImg.Image.Height + " (Original: " + (previewImg.Image.Width / scale).RoundToInt() + "x" + (previewImg.Image.Height / scale).RoundToInt() + ")";
            cutout.Text = "Cutout: " + cutoutW + "x" + cutoutH + " (Original: " + (cutoutW / scale).RoundToInt() + "x" + (cutoutH / scale).RoundToInt() + ")";
        }

        public static bool DroppedImageIsValid(string path)
        {
            try
            {
                MagickImage img = ImgUtils.GetMagickImage(path);
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

        public static void OpenLastOutputFolder()
        {
            if (!string.IsNullOrWhiteSpace(Program.lastOutputDir))
                Process.Start("explorer.exe", Program.lastOutputDir);
        }
    }
}
