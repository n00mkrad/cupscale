using System;
using System.Drawing;
using System.IO;
using Cupscale.IO;
using Cupscale.UI;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
	internal class PreviewMerger
	{
		public static Image currentOriginal;
		public static Image currentOutput;

		public static float offsetX;

		public static float offsetY;

		public static string inputCutoutPath;

		public static string outputCutoutPath;

		public static int scale;

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
			MagickImage val = new MagickImage(Program.lastFilename);
			MagickImage val2 = new MagickImage(outputCutoutPath);
			val.FilterType = (FilterType)1;
			val.Scale(new Percentage(num * 100));
			string text = Path.Combine(Paths.previewOutPath, "preview-input-scaled.png");
			val.Format = (MagickFormat)171;
			val.Quality = (10);
			val.Write(text);
			val.Composite((IMagickImage<ushort>)(object)val2, (Gravity)1, new PointD((double)offsetX, (double)offsetY));
			string text2 = Path.Combine(Paths.previewOutPath, "preview-merged.png");
			val.Write(text2);
			Image image = IOUtils.GetImage(text2);
			currentOriginal = IOUtils.GetImage(text);
			currentOutput = image;
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

		public static void ResetCachedImages()
		{
			currentOriginal = null;
			currentOutput = null;
		}

		public static void ShowOutput()
		{
			if (currentOutput != null)
			{
				UIHelpers.ReplaceImageAtSameScale(PreviewTabHelper.previewImg, currentOutput);
			}
		}

		public static void ShowOriginal()
		{
			if (currentOriginal != null)
			{
				UIHelpers.ReplaceImageAtSameScale(PreviewTabHelper.previewImg, currentOriginal);
			}
		}
	}
}
