using System;
using System.Drawing;
using System.IO;
using System.Windows;
using Cupscale.ImageUtils;
using Cupscale.IO;
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
		//public static int scale;

		public static bool showingOriginal = false;

		public static void Merge ()
		{
			Program.mainForm.SetProgress(100f);
			inputCutoutPath = Path.Combine(Paths.previewPath, "preview.png");
			outputCutoutPath = Path.Combine(Paths.previewOutPath, "preview.png");

			//MagickImage sourceImg = new MagickImage(Paths.tempImgPath);
			Image sourceImg = IOUtils.GetImage(Paths.tempImgPath);
			int scale = GetScale();
			if (sourceImg.Width * scale > 5000 || sourceImg.Height * scale > 5000)
            {
				MergeOnlyCutout();
				MessageBox.Show("The output image is very large (>5000px), so only the cutout will be shown.", "Warning");
				return;
			}
			MergeScrollable();
		}

		static void MergeScrollable ()
        {
			MagickImage sourceImg = new MagickImage(Paths.tempImgPath);
			if (offsetX < 0f)
				offsetX *= -1f;
			if (offsetY < 0f)
				offsetY *= -1f;
			int scale = GetScale();
			offsetX *= scale;
			offsetY *= scale;
			Logger.Log("Merging " + outputCutoutPath + " onto " + Program.lastFilename + " using offset " + offsetX + "x" + offsetY);
			MagickImage cutout = new MagickImage(outputCutoutPath);
			sourceImg.FilterType = Program.currentFilter;
			sourceImg.Resize(new Percentage(scale * 100));
			string scaledPrevPath = Path.Combine(Paths.previewOutPath, "preview-input-scaled.png");
			sourceImg.Format = MagickFormat.Png;
			sourceImg.Quality = 0;  // Save preview as uncompressed PNG for max speed
			sourceImg.Write(scaledPrevPath);
			sourceImg.Composite(cutout, (Gravity)1, new PointD(offsetX, offsetY), CompositeOperator.Replace);
			string mergedPreviewPath = Path.Combine(Paths.previewOutPath, "preview-merged.png");
			sourceImg.Write(mergedPreviewPath);
			Image image = IOUtils.GetImage(mergedPreviewPath);
			MainUIHelper.currentOriginal = IOUtils.GetImage(scaledPrevPath);
			MainUIHelper.currentOutput = image;
			MainUIHelper.currentScale = ImgUtils.GetScale(IOUtils.GetImage(inputCutoutPath), IOUtils.GetImage(outputCutoutPath));
			UIHelpers.ReplaceImageAtSameScale(MainUIHelper.previewImg, image);
			Program.mainForm.SetProgress(0f, "Done.");
		}

		static void MergeOnlyCutout ()
		{
			int scale = GetScale();

			MagickImage originalCutout = new MagickImage(inputCutoutPath);
			originalCutout.FilterType = Program.currentFilter;
			originalCutout.Resize(new Percentage(scale * 100));
			string scaledCutoutPath = Path.Combine(Paths.previewOutPath, "preview-input-scaled.png");
			originalCutout.Format = MagickFormat.Png;
			originalCutout.Quality = 0;  // Save preview as uncompressed PNG for max speed
			originalCutout.Write(scaledCutoutPath);

			MainUIHelper.currentOriginal = IOUtils.GetImage(scaledCutoutPath);
			MainUIHelper.currentOutput = IOUtils.GetImage(outputCutoutPath);

			MainUIHelper.previewImg.Image = MainUIHelper.currentOutput;
			MainUIHelper.previewImg.ZoomToFit();
			MainUIHelper.previewImg.Zoom = (int)Math.Round(MainUIHelper.previewImg.Zoom * 1.01f);
			Program.mainForm.resetImageOnMove = true;
			Program.mainForm.SetProgress(0f, "Done.");
		}

		private static int GetScale()
		{
			MagickImage val = new MagickImage(inputCutoutPath);
			MagickImage val2 = new MagickImage(outputCutoutPath);
			int result = (int)Math.Round((float)val2.Width / (float)val.Width);
			return result;
		}

		public static void ShowOutput()
		{
			if (MainUIHelper.currentOutput != null)
			{
				showingOriginal = false;
				UIHelpers.ReplaceImageAtSameScale(MainUIHelper.previewImg, MainUIHelper.currentOutput);
			}
		}

		public static void ShowOriginal()
		{
			if (MainUIHelper.currentOriginal != null)
			{
				showingOriginal = true;
				UIHelpers.ReplaceImageAtSameScale(MainUIHelper.previewImg, MainUIHelper.currentOriginal);
			}
		}
	}
}
