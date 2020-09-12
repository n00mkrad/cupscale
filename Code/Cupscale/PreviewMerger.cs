using System;
using System.Drawing;
using System.IO;
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
		public static int scale;

		public static bool showingOriginal = false;

		public static void Merge()
		{
			Program.mainForm.SetPreviewProgress(100f);
			inputCutoutPath = Path.Combine(Paths.previewPath, "preview.png");
			outputCutoutPath = Path.Combine(Paths.previewOutPath, "preview.png");
			if (offsetX < 0f)
			{
				offsetX *= -1f;
			}
			if (offsetY < 0f)
			{
				offsetY *= -1f;
			}
			int num = GetScale();
			offsetX *= num;
			offsetY *= num;
			Logger.Log("Merging " + outputCutoutPath + " onto " + Program.lastFilename + " using offset " + offsetX + "x" + offsetY);
			MagickImage sourceImg = new MagickImage(Program.lastFilename);
			MagickImage cutout = new MagickImage(outputCutoutPath);
			sourceImg.FilterType = Program.currentFilter;
			sourceImg.Scale(new Percentage(num * 100));
			string scaledPrevPath = Path.Combine(Paths.previewOutPath, "preview-input-scaled.png");
			sourceImg.Format = MagickFormat.Jpg;
			sourceImg.Quality = 98;
			sourceImg.Write(scaledPrevPath);
			sourceImg.Composite(cutout, (Gravity)1, new PointD(offsetX, offsetY));
			string text2 = Path.Combine(Paths.previewOutPath, "preview-merged.png");
			sourceImg.Write(text2);
			Image image = IOUtils.GetImage(text2);
			PreviewTabHelper.currentOriginal = IOUtils.GetImage(scaledPrevPath);
			PreviewTabHelper.currentOutput = image;
			PreviewTabHelper.currentScale = ImgUtils.GetScale(IOUtils.GetImage(inputCutoutPath), IOUtils.GetImage(outputCutoutPath));
			UIHelpers.ReplaceImageAtSameScale(PreviewTabHelper.previewImg, image);
			Program.mainForm.SetPreviewProgress(0f, "Done.");
		}

		private static int GetScale()
		{
			MagickImage val = new MagickImage(inputCutoutPath);
			MagickImage val2 = new MagickImage(outputCutoutPath);
			int result = (int)Math.Round((float)val2.Width / (float)val.Width);
			Logger.Log("Detected scale is " + result);
			return result;
		}

		public static void ShowOutput()
		{
			if (PreviewTabHelper.currentOutput != null)
			{
				showingOriginal = false;
				UIHelpers.ReplaceImageAtSameScale(PreviewTabHelper.previewImg, PreviewTabHelper.currentOutput);
			}
		}

		public static void ShowOriginal()
		{
			if (PreviewTabHelper.currentOriginal != null)
			{
				showingOriginal = true;
				UIHelpers.ReplaceImageAtSameScale(PreviewTabHelper.previewImg, PreviewTabHelper.currentOriginal);
			}
		}
	}
}
