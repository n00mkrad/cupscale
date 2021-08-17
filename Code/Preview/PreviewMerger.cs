using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.UI;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
    internal class PreviewMerger
    {
        public static float offsetX;
        public static float offsetY;
        public static string inputCutoutPath;
        public static string outputCutoutPath;

        public static bool showingOriginal = false;

        public static void Merge()
        {
            PreviewUI.sw.Stop();
            Program.mainForm.SetProgress(100f);
            inputCutoutPath = Path.Combine(Paths.previewPath, "preview.png.png");
            outputCutoutPath = Directory.GetFiles(Paths.previewOutPath, "preview.*", SearchOption.AllDirectories)[0];

            Image sourceImg = ImgUtils.GetImage(Paths.tempImgPath);
            float scale = GetScale();

            if (sourceImg.Width * scale > 16000 || sourceImg.Height * scale > 16000)
            {
                MergeOnlyCutout();
                Program.ShowMessage("The scaled output image is very large (>16000px), so only the cutout will be shown.", "Warning");
                return;
            }

            MergeScrollable();
        }

        static void MergeScrollable()
        {

            if (offsetX < 0f) offsetX *= -1f;
            if (offsetY < 0f) offsetY *= -1f;
            float scale = GetScale();
            offsetX *= scale;
            offsetY *= scale;
            Logger.Log("[Merger] Merging " + Path.GetFileName(outputCutoutPath) + " onto original using offset " + offsetX + "x" + offsetY);
            Image image = MergeInMemory(scale);
            PreviewUI.currentOriginal = ImgUtils.GetImage(Paths.tempImgPath);
            PreviewUI.currentOutput = image;
            PreviewUI.currentScale = ImgUtils.GetScaleFloat(ImgUtils.GetImage(inputCutoutPath), ImgUtils.GetImage(outputCutoutPath));
            UIHelpers.ReplaceImageAtSameScale(PreviewUI.previewImg, image);
            Program.mainForm.SetProgress(0f, "Done.");
        }


        public static Image MergeInMemory(float scale)
        {
            Image scaledSourceImg;
            int oldWidth;
            int newWidth;

            if (!(ImageProcessing.preScaleMode == Upscale.ScaleMode.Percent && ImageProcessing.preScaleValue == 100))
            {
                string tempScaledSourceImagePath = Path.Combine(Paths.tempImgPath.GetParentDir(), "scaled-source.png");
                MagickImage scaledSourceMagickImg = new MagickImage(Paths.tempImgPath);
                oldWidth = scaledSourceMagickImg.Width;
                scaledSourceMagickImg = ImageProcessing.ResizeImagePre(scaledSourceMagickImg);
                newWidth = scaledSourceMagickImg.Width;
                scaledSourceMagickImg.Write(tempScaledSourceImagePath);
               scaledSourceImg = ImgUtils.GetImage(tempScaledSourceImagePath);
            }
            else
            {
                scaledSourceImg = ImgUtils.GetImage(Paths.tempImgPath);
                oldWidth = scaledSourceImg.Width;
                newWidth = scaledSourceImg.Width;
            }

            float preScale = (float)oldWidth / (float)newWidth;
            Image cutout = ImgUtils.GetImage(outputCutoutPath);

            int scaledWidth = (scaledSourceImg.Width * scale).RoundToInt();
            int scaledHeight = (scaledSourceImg.Height * scale).RoundToInt();

            if (scaledWidth == cutout.Width && scaledHeight == cutout.Height)
            {
                Logger.Log("[Merger] Cutout is the entire image - skipping merge");
                return cutout;
            }
            
            var destImage = new Bitmap(scaledWidth, scaledHeight);

            using (var gfx = Graphics.FromImage(destImage))
            {
                gfx.CompositingMode = CompositingMode.SourceCopy;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.InterpolationMode = (Program.currentFilter == FilterType.Point) ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.DrawImage(scaledSourceImg, 0, 0, destImage.Width, destImage.Height);       // Scale up
                gfx.DrawImage(cutout, (offsetX / preScale).RoundToInt(), (offsetY / preScale).RoundToInt());     // Overlay cutout
            }

            return destImage;
        }

        static void MergeOnlyCutout()
        {
            float scale = GetScale();

            MagickImage originalCutout = ImgUtils.GetMagickImage(inputCutoutPath);
            originalCutout.FilterType = Program.currentFilter;
            originalCutout.Resize(new Percentage(scale * 100));
            string scaledCutoutPath = Path.Combine(Paths.previewOutPath, "preview-input-scaled.png");
            originalCutout.Format = MagickFormat.Png;
            originalCutout.Quality = 0;  // Save preview as uncompressed PNG for max speed
            originalCutout.Write(scaledCutoutPath);

            PreviewUI.currentOriginal = ImgUtils.GetImage(scaledCutoutPath);
            PreviewUI.currentOutput = ImgUtils.GetImage(outputCutoutPath);

            PreviewUI.previewImg.Image = PreviewUI.currentOutput;
            PreviewUI.previewImg.ZoomToFit();
            PreviewUI.previewImg.Zoom = (int)Math.Round(PreviewUI.previewImg.Zoom * 1.01f);
            Program.mainForm.resetImageOnMove = true;
            Program.mainForm.SetProgress(0f, "Done.");
        }

        private static float GetScale()
        {
            MagickImage val = ImgUtils.GetMagickImage(inputCutoutPath);
            MagickImage val2 = ImgUtils.GetMagickImage(outputCutoutPath);
            float result = (float)val2.Width / (float)val.Width;
            return result;
        }

        public static void ShowOutput()
        {
            if (PreviewUI.currentOutput != null)
            {
                showingOriginal = false;
                UIHelpers.ReplaceImageAtSameScale(PreviewUI.previewImg, PreviewUI.currentOutput);
            }
        }

        public static void ShowOriginal()
        {
            if (PreviewUI.currentOriginal != null)
            {
                showingOriginal = true;
                UIHelpers.ReplaceImageAtSameScale(PreviewUI.previewImg, PreviewUI.currentOriginal);
            }
        }
    }
}
