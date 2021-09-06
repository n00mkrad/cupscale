using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.Data;
using Cupscale.Forms;
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
    internal class PreviewUi
    {
        public enum PreviewMode { None, Cutout, FullImage }
        public enum MdlMode { Single, Interp, Chain, Advanced }
        public static MdlMode currentMode;
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
            interpValue = 50;
            previewImg = imgBox;
            model1 = model1Btn;
            model2 = model2Btn;
            outputFormat = formatBox;
            overwrite = overwriteBox;
        }

        public static string lastOutfile;

        public static Stopwatch sw = new Stopwatch();

        public static async Task UpscaleImage()
        {
            if (previewImg.Image == null)
            {
                Program.ShowMessage("Please load an image first!", "Error");
                return;
            }

            Program.mainForm.SetBusy(true);
            IoUtils.ClearDir(Paths.imgInPath);
            IoUtils.ClearDir(Paths.imgOutPath);
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
            sw.Restart();

            try
            {
                await Upscale.Run(Paths.imgInPath, Paths.imgOutPath, mdl, false, Config.GetBool("alpha"), PreviewMode.None);
                if (Program.canceled) return;
                outImg = Upscale.GetOutputImg();
                Program.mainForm.SetProgress(100f, "Post-Processing...");
                await Task.Delay(50);
                await PostProcessing.PostprocessingSingle(outImg, false);
                string outFilename = Upscale.FilenamePostprocess(lastOutfile);
                await Upscale.CopyImagesTo(Path.GetDirectoryName(Program.lastImgPath));
            }
            catch (Exception e)
            {
                Program.mainForm.SetProgress(0f, "Cancelled.");
                if (Program.canceled)
                    return;
                if (e.StackTrace.Contains("Index"))
                    Program.ShowMessage("The upscale process seems to have exited before completion!", "Error");
                Logger.ErrorMessage("An error occured during upscaling:", e);
            }

            if (!Program.canceled)
                Program.mainForm.SetProgress(0, $"Done - Upscaling took {(sw.ElapsedMilliseconds / 1000f).ToString("0.0")}s");

            Program.mainForm.SetBusy(false);
        }

        static void Cancel(string reason = "")
        {
            if (string.IsNullOrWhiteSpace(reason))
                Program.mainForm.SetProgress(0f, "Cancelled.");
            else
                Program.mainForm.SetProgress(0f, "Cancelled: " + reason);
            string inputImgPath = Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastImgPath));
        }

        public static void TabSelected()
        {
            Program.mainForm.SetButtonText("Upscale And Save");
        }

        public static bool HasValidModelSelection(bool showErrorMsgsIfInvalid = true)
        {
            Implementations.Implementation ai = Upscale.currentAi;
            bool ncnn = ai == Implementations.Imps.esrganNcnn || ai == Implementations.Imps.realEsrganNcnn;

            if (ai == Implementations.Imps.esrganPytorch)
            {
                bool valid = true;

                if (NcnnUtils.IsDirNcnnModel(Program.currentModel1) || NcnnUtils.IsDirNcnnModel(Program.currentModel2))
                    valid = false;  // NCNN models not compatible with pytorch

                if (!valid && showErrorMsgsIfInvalid)
                {
                    Program.ShowMessage("Invalid model selection - You have selected one or more models that are not compatible with this implementation!", "Error");
                    return false;
                }

                if (model1.Enabled && !File.Exists(Program.currentModel1))
                    valid = false;
                if (model2.Enabled && !File.Exists(Program.currentModel2))
                    valid = false;

                if (!valid && showErrorMsgsIfInvalid)
                    Program.ShowMessage("Invalid model selection.\nMake sure you have selected a model and that the file still exists.", "Error");

                return valid;
            }

            if (ncnn)
            {
                bool valid = true;

                if (!Program.mainForm.IsSingleModleMode())
                    valid = false;

                if (!valid && showErrorMsgsIfInvalid)
                {
                    Program.ShowMessage("Invalid model selection - NCNN does not support interpolation or chaining.", "Error");
                    return false;
                }

                return valid;
            }

            return true;
        }

        static string CopyImage()
        {
            string outpath = Path.Combine(Paths.imgInPath, Path.GetFileName(Program.lastImgPath));
            try
            {
                File.Copy(Program.lastImgPath, outpath);
            }
            catch (Exception e)
            {
                Program.ShowMessage("Error trying to copy file: \n\n" + e.Message, "Error");
                return null;
            }
            return outpath;
        }


        public static async void UpscalePreview(bool fullImage = false)
        {
            if (!HasValidModelSelection())
                return;

            Upscale.currentMode = Upscale.UpscaleMode.Preview;
            Program.mainForm.SetBusy(true);
            Program.mainForm.SetProgress(2f, "Preparing...");
            Program.mainForm.resetState = new Cupscale.PreviewState(previewImg.Image, previewImg.Zoom, previewImg.AutoScrollPosition);
            await Task.Delay(20);
            ResetCachedImages();
            IoUtils.ClearDir(Paths.imgInPath);
            IoUtils.ClearDir(Paths.previewPath);
            IoUtils.ClearDir(Paths.previewOutPath);
            PreviewUi.PreviewMode prevMode = PreviewUi.PreviewMode.Cutout;

            if (fullImage)
            {
                prevMode = PreviewUi.PreviewMode.FullImage;
                if (!IoUtils.TryCopy(Paths.tempImgPath, Path.Combine(Paths.previewPath, "preview.png"), true)) return;
            }
            else
            {
                SaveCurrentCutout();
            }

            ClipboardComparison.originalPreview = (Bitmap)ImgUtils.GetImage(Directory.GetFiles(Paths.previewPath, "*.png.*", SearchOption.AllDirectories)[0]);
            await ImageProcessing.PreProcessImages(Paths.previewPath, !bool.Parse(Config.Get("alpha")));
            string tilesize = Config.Get("tilesize");
            bool alpha = bool.Parse(Config.Get("alpha"));

            sw.Restart();

            ModelData mdl = new ModelData();

            if (Upscale.currentAi.supportsModels)
            {
                if (currentMode == MdlMode.Single)
                {
                    string mdl1 = Program.currentModel1;
                    if (string.IsNullOrWhiteSpace(mdl1)) return;
                    mdl = new ModelData(mdl1, null, ModelData.ModelMode.Single);
                }

                if (currentMode == MdlMode.Interp)
                {
                    string mdl1 = Program.currentModel1;
                    string mdl2 = Program.currentModel2;
                    if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                    mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Interp, interpValue);
                }

                if (currentMode == MdlMode.Chain)
                {
                    string mdl1 = Program.currentModel1;
                    string mdl2 = Program.currentModel2;
                    if (string.IsNullOrWhiteSpace(mdl1) || string.IsNullOrWhiteSpace(mdl2)) return;
                    mdl = new ModelData(mdl1, mdl2, ModelData.ModelMode.Chain);
                }

                if (currentMode == MdlMode.Advanced)
                {
                    mdl = new ModelData(null, null, ModelData.ModelMode.Advanced);
                }
            }

            await Upscale.Run(Paths.previewPath, Paths.previewOutPath, mdl, false, alpha, prevMode);

            if (!Program.canceled)
                Program.mainForm.SetProgress(0, $"Done - Upscaling took {(sw.ElapsedMilliseconds / 1000f).ToString("0.0")}s");
            
            Program.mainForm.SetBusy(false);
        }

        public static async Task ScalePreviewOutput()
        {
            if (ImageProcessing.postScaleMode == Upscale.ScaleMode.Percent && ImageProcessing.postScaleValue == 100)   // Skip if target scale is 100%)
                return;

            Program.mainForm.SetProgress(1f, "Resizing preview output...");
            await Task.Delay(1);
            MagickImage img = ImgUtils.GetMagickImage(Directory.GetFiles(Paths.previewOutPath, "*.png.*", SearchOption.AllDirectories)[0]);
            MagickImage magickImage = ImageProcessing.ResizeImagePost(img);
            img = magickImage;
            img.Write(img.FileName);
            //string img = Directory.GetFiles(Paths.previewOutPath, "*.png.*", SearchOption.AllDirectories)[0];
            //ImageProcessing.ResizeImagePost(img);
        }

        public static void SaveCurrentCutout()
        {
            UiHelpers.ReplaceImageAtSameScale(previewImg, ImgUtils.GetImage(Paths.tempImgPath));
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
            Logger.Log("[MainUI] Saving current region to bitmap. Offset: " + previewImg.AutoScrollPosition.X + "x" + previewImg.AutoScrollPosition.Y);
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
                if (img.Width > 8192 || img.Height > 8192)
                {
                    Program.ShowMessage("Image is too big for the preview!\nPlease use images with less than 8192 pixels on either side.", "Error");
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.ErrorMessage("Failed to open image:", e);
                return false;
            }
            return true;
        }

        public static void OpenLastOutputFolder()
        {
            if (!string.IsNullOrWhiteSpace(Program.lastOutputDir))
                Process.Start("explorer.exe", Program.lastOutputDir);
        }

        public static async Task LoadPatronListCsv(Control patronsLabel)
        {
            try
            {
                string url = $"https://raw.githubusercontent.com/n00mkrad/flowframes/main/patrons.csv";
                var client = new WebClient();
                var csvData = await client.DownloadStringTaskAsync(new Uri(url));
                patronsLabel.Text = ParsePatreonCsv(csvData);
            }
            catch (Exception e)
            {
                Logger.Log($"Failed to load patreon CSV: {e.Message}");
            }
        }

        public static string ParsePatreonCsv(string csvData)
        {
            try
            {
                Logger.Log("Parsing Patrons from CSV...", true);
                List<string> goldPatrons = new List<string>();
                List<string> silverPatrons = new List<string>();
                string str = "Gold:\n";
                string[] lines = csvData.SplitIntoLines().Select(x => x.Replace(";", ",")).ToArray();

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(',');
                    if (i == 0 || line.Length < 10 || values.Length < 5) continue;
                    string name = values[0].Trim();
                    string status = values[4].Trim();
                    string tier = values[9].Trim();

                    if (status.Contains("Active"))
                    {
                        if (tier.Contains("Gold"))
                            goldPatrons.Add(name.Split('(')[0].Trunc(30));

                        if (tier.Contains("Silver"))
                            silverPatrons.Add(name.Split('(')[0].Trunc(30));
                    }
                }

                Logger.Log($"Found {goldPatrons.Count} Gold Patrons, {silverPatrons.Count} Silver Patrons", true);

                int silverAmount = 35;

                str += string.Join(" - ", goldPatrons);
                str += "\n\nSilver:\n";
                str += string.Join(" - ", silverPatrons.Take(silverAmount));

                if(silverPatrons.Count - silverAmount > 0)
                    str += $"\n...and {silverPatrons.Count - silverAmount} more!";

                return str;
            }
            catch (Exception e)
            {
                Logger.Log($"Failed to parse Patreon CSV: {e.Message}\n{e.StackTrace}", true);
                return "Failed to load patron list.";
            }
        }
    }
}
