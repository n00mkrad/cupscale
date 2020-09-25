using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.UI;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale
{
    class ClipboardPreview
    {
        public static Bitmap originalPreview;
        public static Bitmap resultPreview;

        public static async void CopyToClipboardSideBySide(bool saveToFile, bool fullImage = false)
        {
            int footerHeight = 45;

            try
            {
                if (fullImage)
                {
                    originalPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview-input-scaled.png")));
                    resultPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview-merged.png")));
                }
                else
                {
                    originalPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewPath, "preview.png")));
                    resultPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview.png.tmp")));
                }
            }
            catch
            {
                MessageBox.Show("Error creating clipboard preview!", "Error");
            }

            int comparisonMod = 1;
            int newWidth = comparisonMod * resultPreview.Width, newHeight = comparisonMod * resultPreview.Height;

            Bitmap outputImage = new Bitmap(2 * newWidth, newHeight + footerHeight);
            string modelName = Program.lastModelName;
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(originalPreview, new Rectangle(0, 0, newWidth, newHeight),
                    new Rectangle(new Point(), originalPreview.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(resultPreview, new Rectangle(newWidth, 0, newWidth, newHeight),
                    new Rectangle(new Point(), resultPreview.Size), GraphicsUnit.Pixel);

                Bitmap Bmp = new Bitmap(2 * newWidth, footerHeight);
                Color color = Color.FromArgb(22, 22, 22);
                using (Graphics gfx = Graphics.FromImage(Bmp))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    gfx.FillRectangle(brush, 0, 0, 2 * newWidth, footerHeight);
                }
                graphics.DrawImage(Bmp, 0, newHeight);

                GraphicsPath p = new GraphicsPath();
                int fontSize = 19;
                SizeF s = new Size(999999999, 99999999);

                Font font = new Font("Times New Roman", graphics.DpiY * fontSize / 72);

                string barString = "[CS] " + Path.GetFileName(Program.lastFilename) + " - " + modelName;

                int cf = 0, lf = 0;
                while (s.Width >= 2 * newWidth)
                {
                    fontSize--;
                    font = new Font(FontFamily.GenericSansSerif, graphics.DpiY * fontSize / 72, FontStyle.Regular);
                    s = graphics.MeasureString(barString, font, new SizeF(), new StringFormat(), out cf, out lf);
                }
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                double a = graphics.DpiY * fontSize / 72;
                stringFormat.LineAlignment = StringAlignment.Center;

                double contrastW = GetColorContrast(color, Color.White);
                double contrastB = GetColorContrast(color, Color.Black);
                Brush textBrush = contrastW < 3.0 ? Brushes.Black : Brushes.White;

                graphics.DrawString(
                    $"{barString}",
                    font,
                    textBrush,
                    new Rectangle(0, newHeight, 2 * newWidth, footerHeight - 0),
                    stringFormat);
            }
            try
            {
                if (saveToFile)
                    await SaveComparisonToFile(outputImage);
                else
                    Clipboard.SetDataObject(outputImage);
            }
            catch
            {
                MessageBox.Show("Failed to save comparison.", "Error");
            }
        }

        public static async void CopyToClipboardSlider(bool saveToFile, bool fullImage = false)
        {
            int footerHeight = 45;

            try
            {
                if (fullImage)
                {
                    originalPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview-input-scaled.png")));
                    resultPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview-merged.png")));
                }
                else
                {
                    originalPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewPath, "preview.png")));
                    resultPreview = new Bitmap(ImgUtils.GetImage(Path.Combine(IO.Paths.previewOutPath, "preview.png.tmp")));
                }
            }
            catch
            {
                MessageBox.Show("Error creating clipboard preview!", "Error");
            }
            

            int comparisonMod = 1;
            //int.TryParse(comparisonMod_comboBox.SelectedValue.ToString(), out comparisonMod);
            int newWidth = comparisonMod * resultPreview.Width, newHeight = comparisonMod * resultPreview.Height;

            Bitmap outputImage = new Bitmap(newWidth, newHeight + footerHeight);
            string modelName = Program.lastModelName;
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                int halfWidth = (int)Math.Round(newWidth * 0.5f);
                Bitmap croppedOutput = resultPreview.Clone(new Rectangle(halfWidth, 0, newWidth - halfWidth, newHeight), resultPreview.PixelFormat);

                graphics.DrawImage(originalPreview, 0, 0, newWidth, newHeight);     // First half
                graphics.DrawImage(croppedOutput, halfWidth, 0);        // Second half
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), halfWidth - 2, 0, 4, newHeight);   // Line

                Bitmap Bmp = new Bitmap(newWidth, footerHeight);
                Color color = Color.FromArgb(22, 22, 22);
                using (Graphics gfx = Graphics.FromImage(Bmp))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    gfx.FillRectangle(brush, 0, 0, newWidth, footerHeight); ;
                }
                graphics.DrawImage(Bmp, 0, newHeight);

                GraphicsPath p = new GraphicsPath();
                int fontSize = 19;
                SizeF s = new Size(999999999, 99999999);

                Font font = new Font("Times New Roman", graphics.DpiY * fontSize / 72);

                string barString = "[CS] " + Path.GetFileName(Program.lastFilename) + " - " + modelName;

                int cf = 0, lf = 0;
                while (s.Width >= newWidth)
                {
                    fontSize--;
                    font = new Font(FontFamily.GenericSansSerif, graphics.DpiY * fontSize / 72, FontStyle.Regular);
                    s = graphics.MeasureString(barString, font, new SizeF(), new StringFormat(), out cf, out lf);
                }
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                double a = graphics.DpiY * fontSize / 72;
                stringFormat.LineAlignment = StringAlignment.Center;

                double contrastW = GetColorContrast(color, Color.White);
                double contrastB = GetColorContrast(color, Color.Black);

                Brush textBrush = contrastW < 3.0 ? Brushes.Black : Brushes.White;

                graphics.DrawString(
                    $"{barString}",
                    font,
                    textBrush,
                    new Rectangle(0, newHeight, newWidth, footerHeight - 0),
                    stringFormat);
            }
            try
            {
                if (saveToFile)
                    await SaveComparisonToFile(outputImage);
                else
                    Clipboard.SetDataObject(outputImage);
            }
            catch
            {
                MessageBox.Show("Failed to save comparison.", "Error");
            }
        }

        static async Task SaveComparisonToFile (Image outputImage)
        {
            string comparisonSavePath = Path.ChangeExtension(Program.lastFilename, null) + "-comparison.png";
            outputImage.Save(comparisonSavePath);
            await ImageProcessing.ConvertImage(comparisonSavePath, GetSaveFormat(), false, false);
            MessageBox.Show("Saved current comparison to:\n\n" + Path.ChangeExtension(comparisonSavePath, null), "Message");
        }

        static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        static double GetColorContrast(Color background, Color text)
        {
            double L1 = 0.2126 * background.R / 255 + 0.7152 * background.G / 255 + 0.0722 * background.B / 255;
            double L2 = 0.2126 * text.R / 255 + 0.7152 * text.G / 255 + 0.0722 * text.B / 255;
            if (L1 > L2)
                return (L1 + 0.05) / (L2 + 0.05);
            else
                return (L2 + 0.05) / (L1 + 0.05);

        }

        public static async void BeforeAfterAnim (bool save, bool h264)
        {

            string ext = "gif";
            if (h264) ext = "mp4";

            DialogForm dialogForm = new DialogForm("Creating comparison " + ext.ToUpper() + "...");

            string tempPath = Path.Combine(IOUtils.GetAppDataDir(), "giftemp");
            string framesPath = Path.Combine(tempPath, "frames");
            IOUtils.DeleteContentsOfDir(tempPath);
            Directory.CreateDirectory(framesPath);

            string img1 = Path.Combine(IO.Paths.previewPath, "preview.png");
            string img2 = Path.Combine(IO.Paths.previewOutPath, "preview.png.tmp");

            Image image1 = ImgUtils.GetImage(img1);
            Image image2 = ImgUtils.GetImage(img2);
            float scale = (float)image2.Width / (float)image1.Width;
            Logger.Log("Scale for animation: " + scale);

            string outpath = Path.Combine(tempPath, "comparison." + ext);

            if (image2.Width <= 2048 && image2.Height <= 2048)
            {
                ImgUtils.GetImage(img1).Scale(scale, InterpolationMode.NearestNeighbor).Save(Path.Combine(framesPath, "0.png"));
                File.Copy(img2, Path.Combine(framesPath, "1.png"), true);
                if (h264)
                {
                    await FFmpegCommands.FramesToOneFpsMp4(framesPath, false, 14, 9, "", false);
                    File.Move(Path.Combine(tempPath, "frames." + ext), outpath);
                }
                else
                {
                    await FFmpeg.RunGifski(" -r 1 -W 2048 -q -o " + outpath.WrapPath() + " \"" + framesPath + "/\"*.\"png\"");
                }

                if (save)
                {
                    string comparisonSavePath = Path.ChangeExtension(Program.lastFilename, null) + "-comparison." + ext;
                    File.Copy(outpath, comparisonSavePath, true);
                    dialogForm.Close();
                    MessageBox.Show("Saved current comparison to:\n\n" + comparisonSavePath, "Message");
                }
                else
                {
                    StringCollection paths = new StringCollection();
                    paths.Add(outpath);
                    Clipboard.SetFileDropList(paths);
                    dialogForm.Close();
                    MessageBox.Show("The " + ext.ToUpper() + " file has been copied. You can paste it into any folder.\n" +
                        "Please note that pasting it into Discord or other programs won't work as the clipboard can't hold animated images.", "Message");
                }
                
            }
            else
            {
                MessageBox.Show("The preview is too large for making an animation. Please create a smaller cutout or choose a different comparison type.", "Error");
            }

            dialogForm.Close();
        }

        static ImageProcessing.Format GetSaveFormat ()
        {
            ImageProcessing.Format saveFormat = ImageProcessing.Format.PngFast;
            if(Config.GetInt("previewFormat") == 1)
                saveFormat = ImageProcessing.Format.Jpeg;
            if (Config.GetInt("previewFormat") == 2)
                saveFormat = ImageProcessing.Format.Weppy;
            return saveFormat;
        }
    }
}