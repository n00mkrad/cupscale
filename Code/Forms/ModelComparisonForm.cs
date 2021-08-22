using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.OS;
using Cupscale.UI;
using Cyotek.Windows.Forms;
using HTAlt.WinForms;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale.Forms
{
    public partial class ModelComparisonForm : Form
    {
        public string currentSourcePath;
        public bool cutoutMode;

        public ModelComparisonForm()
        {
            InitializeComponent();
        }

        private void ModelComparisonForm_Load(object sender, EventArgs e)
        {
            UiHelpers.InitCombox(compositionMode, 0);
            UiHelpers.InitCombox(comparisonMode, 0);
            UiHelpers.InitCombox(scaleFactor, 2);
            UiHelpers.InitCombox(cropMode, 0);

            if (ModelComparisonTool.compositionModeComboxIndex >= 0)
                compositionMode.SelectedIndex = ModelComparisonTool.compositionModeComboxIndex;

            if (ModelComparisonTool.comparisonModeComboxIndex >= 0)
                comparisonMode.SelectedIndex = ModelComparisonTool.comparisonModeComboxIndex;

            if (ModelComparisonTool.scaleComboxIndex >= 0)
                scaleFactor.SelectedIndex = ModelComparisonTool.scaleComboxIndex;

            if (ModelComparisonTool.cropModeComboxIndex >= 0)
                cropMode.SelectedIndex = ModelComparisonTool.cropModeComboxIndex;

            if (!string.IsNullOrWhiteSpace(ModelComparisonTool.lastCompositionModels))
                modelPathsBox.Text = ModelComparisonTool.lastCompositionModels;
        }

        private void addModelBtn_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(null, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    modelPathsBox.AppendText(modelForm.selectedModel + Environment.NewLine);
            }
        }

        private async void runBtn_Click(object sender, EventArgs e)
        {
            if(PreviewUi.previewImg.Image == null || !File.Exists(Paths.tempImgPath))
            {
                Program.ShowMessage("No image loaded!", "Error");
                return;
            }
            Enabled = false;
            cutoutMode = cropMode.SelectedIndex == 1;
            if (cutoutMode)
            {
                IoUtils.ClearDir(Paths.previewPath);
                PreviewUi.SaveCurrentCutout();
                currentSourcePath = Path.Combine(Paths.previewPath, "preview.png");
            }
            else
            {
                currentSourcePath = Paths.tempImgPath;
            }
            string[] lines = Regex.Split(modelPathsBox.Text, "\r\n|\r|\n");
            if(comparisonMode.SelectedIndex == 0)
            {
                string outpath = Path.Combine(Paths.imgOutPath, "!Original.png");
                await ImageProcessing.ConvertImage(currentSourcePath, GetSaveFormat(), false, ImageProcessing.ExtMode.UseNew, false, outpath);
                await ProcessImage(outpath, "Original");
            }
            for (int i = 0; i < lines.Length; i++)
            {
                if (!File.Exists(lines[i]))
                    continue;
                ModelData mdl = new ModelData(lines[i], null, ModelData.ModelMode.Single);
                await DoUpscale(i, mdl, !cutoutMode);
            }
            bool vert = compositionMode.SelectedIndex == 1;
            MagickImage merged = ImgUtils.MergeImages(Directory.GetFiles(Paths.imgOutPath, "*.png", SearchOption.AllDirectories), vert, true);
            string mergedPath = Path.Combine(Paths.imgOutPath, Path.GetFileNameWithoutExtension(Program.lastImgPath) + "-composition");
            mergedPath = Path.ChangeExtension(mergedPath, GetSaveExt());
            merged.Write(mergedPath);
            await Upscale.CopyImagesTo(Program.lastImgPath.GetParentDir());
            IoUtils.ClearDir(Paths.previewPath);
            Enabled = true;
            Program.ShowMessage("Saved model composition to " + Program.lastImgPath.GetParentDir() + "\\" + Path.GetFileName(mergedPath), "Message");
        }

        static ImageProcessing.Format GetSaveFormat()
        {
            ImageProcessing.Format saveFormat = ImageProcessing.Format.PngFast;
            if (Config.GetInt("previewFormat") == 1)
                saveFormat = ImageProcessing.Format.Jpeg;
            if (Config.GetInt("previewFormat") == 2)
                saveFormat = ImageProcessing.Format.Weppy;
            return saveFormat;
        }

        static string GetSaveExt ()
        {
            string ext = "png";

            if (Config.GetInt("previewFormat") == 1)
                ext = "jpg";

            if (Config.GetInt("previewFormat") == 2)
                ext = "webp";

            return ext;
        }

        async Task DoUpscale (int index, ModelData mdl, bool fullImage)
        {
            if (PreviewUi.previewImg.Image == null)
            {
                Program.ShowMessage("Please load an image first!", "Error");
                return;
            }

            Program.mainForm.SetBusy(true);

            Upscale.currentMode = Upscale.UpscaleMode.Composition;

            string outImg = null;

            try
            {
                string inpath = Paths.previewPath;
                if (fullImage) inpath = Paths.tempImgPath.GetParentDir();
                await Upscale.Run(inpath, Paths.compositionOut, mdl, false, Config.GetBool("alpha"), PreviewUi.PreviewMode.None);
                outImg = Directory.GetFiles(Paths.compositionOut, "*.png", SearchOption.AllDirectories)[0];
                await PostProcessing.PostprocessingSingle(outImg, false);
                await ProcessImage(PreviewUi.lastOutfile, mdl.model1Name);
                IoUtils.TryCopy(PreviewUi.lastOutfile, Path.Combine(Paths.imgOutPath, $"{index}-{mdl.model1Name}.png"), true);
            }
            catch (Exception e)
            {
                if (Program.canceled) return;

                if (e.Message.ToLower().Contains("index"))
                    Program.ShowMessage("The upscale process seems to have exited before completion!", "Error");

                Program.Cancel($"An error occured: {e.Message}");
            }

            Program.mainForm.SetProgress(0, "Done.");
            Program.mainForm.SetBusy(false);
        }

        async Task ProcessImage (string path, string text)
        {
            int scale = scaleFactor.GetInt();
            Image source = ImgUtils.GetImage(currentSourcePath);
            int newWidth = source.Width * scale;
            Logger.Log($"int newWidth ({newWidth}) = source.Width({source.Width}) * scale({scale});");
            Upscale.Filter filter = (Program.currentFilter == FilterType.Point) ? Upscale.Filter.Nearest : Upscale.Filter.Bicubic;
            Logger.Log("Scaling image for composition...");
            MagickImage img = new MagickImage(path);
            img = ImageProcessing.ResizeImageAdvancedMagick(img, newWidth, Upscale.ScaleMode.PixelsWidth, filter, false);
            img.Write(path);
            //ImgSharpUtils.ResizeImageAdvanced(path, newWidth, Upscale.ScaleMode.PixelsWidth, filter, false);
            AddText(path, text);
        }

        void AddText(string path, string text)
        {
            Logger.Log("Adding text: " + text);
            int footerHeight = 45;
            Image baseImg = ImgUtils.GetImage(path);
            Logger.Log($"baseImg: {baseImg.Width}x{baseImg.Height}");
            int heightWithFooter = baseImg.Height + footerHeight;
            Bitmap img = new Bitmap(baseImg.Width, heightWithFooter);
            Logger.Log($"img: {img.Width}x{img.Height}");
            using (Graphics graphics = Graphics.FromImage(img))
            {
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                graphics.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), 0, 0, baseImg.Width, heightWithFooter);
                graphics.DrawImage(baseImg, 0, 0, baseImg.Width, baseImg.Height);

                GraphicsPath p = new GraphicsPath();
                int fontSize = 19;
                SizeF s = new Size(999999999, 99999999);

                Font font = new Font("Times New Roman", graphics.DpiY * fontSize / 72);

                int cf = 0, lf = 0;
                while (s.Width >= img.Width)
                {
                    fontSize--;
                    font = new Font(FontFamily.GenericSansSerif, graphics.DpiY * fontSize / 72, FontStyle.Regular);
                    s = graphics.MeasureString(text, font, new SizeF(), new StringFormat(), out cf, out lf);
                }
                StringFormat stringFormat = new StringFormat();
                //stringFormat.Alignment = StringAlignment.Center;

                double a = graphics.DpiY * fontSize / 72;
                //stringFormat.LineAlignment = StringAlignment.Center;

                //Brush textBrush = Brushes.White;
                //graphics.DrawString(text, font, textBrush, new Rectangle(0, img.Height, img.Width, footerHeight - 0), stringFormat);

                graphics.DrawString(text, font, Brushes.White, new PointF(0, img.Height - footerHeight));
            }
            Logger.Log("Saving img with size " + img.Width + "x" + img.Height);
            img.Save(path);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ModelComparisonTool.lastCompositionModels = modelPathsBox.Text;
            Close();
        }

        private void ModelComparisonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ModelComparisonTool.lastCompositionModels = modelPathsBox.Text;
            ModelComparisonTool.comparisonModeComboxIndex = comparisonMode.SelectedIndex;
            ModelComparisonTool.compositionModeComboxIndex = compositionMode.SelectedIndex;
            ModelComparisonTool.scaleComboxIndex = scaleFactor.SelectedIndex;
            ModelComparisonTool.cropModeComboxIndex = cropMode.SelectedIndex;
        }
    }
}
