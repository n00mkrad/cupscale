using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.Cupscale;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.UI;
using ImageMagick;
using ImageMagick.Formats.Bmp;
using ImageMagick.Formats.Dds;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
	internal class ImageProcessing
	{
		public enum Format { Source, PngOpti, PngFast, PngRaw, Jpeg, Weppy, BMP, TGA, DDS }

		public static Upscale.Filter currentFilter = Upscale.Filter.Mitchell;
		public static Upscale.ScaleMode currentScaleMode = Upscale.ScaleMode.Percent;
		public static int currentScaleValue = 100;
		public static bool onlyDownscale = true;

		public static void ChangeOutputExtensions(string newExtension)
		{
			string path = Paths.imgOutPath;
			DirectoryInfo d = new DirectoryInfo(path);
			FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
			foreach (FileInfo file in files)
			{
				string targetPath = file.FullName.Substring(0, file.FullName.Length - 4);
				if (File.Exists(targetPath)) File.Delete(targetPath);
				file.MoveTo(targetPath);
			}
			files = d.GetFiles("*", SearchOption.AllDirectories);
			foreach (FileInfo file2 in files)
			{
				string targetPath = Path.ChangeExtension(file2.FullName, newExtension);
				if (File.Exists(targetPath)) File.Delete(targetPath);
				file2.MoveTo(targetPath);
			}
		}

		public static async Task ConvertImagesToOriginalFormat(bool postprocess, bool setProgress = true)
		{
			string path = Paths.imgOutPath;
			DirectoryInfo d = new DirectoryInfo(path);
			FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
			foreach (FileInfo file in files)
			{
				file.MoveTo(file.FullName.Substring(0, file.FullName.Length - 4));
			}
			files = d.GetFiles("*", SearchOption.AllDirectories);
			int i = 1;
			foreach (FileInfo file2 in files)
			{
				if (GetTrimmedExtension(file2) == "png")
					break;
				Format format = Format.PngOpti;

				if (GetTrimmedExtension(file2) == "jpg" || GetTrimmedExtension(file2) == "jpeg")
					format = Format.Jpeg;

				if (GetTrimmedExtension(file2) == "webp")
					format = Format.Weppy;

				if (GetTrimmedExtension(file2) == "bmp")
					format = Format.BMP;

				if (GetTrimmedExtension(file2) == "tga")
					format = Format.TGA;

				if (GetTrimmedExtension(file2) == "dds")
					format = Format.DDS;

				if(setProgress)
					Program.mainForm.SetProgress(Program.GetPercentage(i, files.Length), "Processing " + file2.Name);

				if (postprocess)
					await PostProcessImage(file2.FullName, format, false);
				else
					await ConvertImage(file2.FullName, format, false, false, true);

				i++;
			}
		}

		public static async Task ConvertImageToOriginalFormat(string path, bool postprocess, bool batchProcessing, bool setProgress = true)
		{
			FileInfo file2 = new FileInfo(path);
			//string newPath = file.FullName.Substring(0, file.FullName.Length - 4);
			//file.MoveTo(newPath);
			//FileInfo file2 = new FileInfo(newPath);

			//if (GetTrimmedExtension(file2) == "png")
			//break;

			Format format = Format.PngFast;

			if (GetTrimmedExtension(file2) == "jpg" || GetTrimmedExtension(file2) == "jpeg")
				format = Format.Jpeg;

			if (GetTrimmedExtension(file2) == "webp")
				format = Format.Weppy;

			if (GetTrimmedExtension(file2) == "bmp")
				format = Format.BMP;

			if (GetTrimmedExtension(file2) == "tga")
				format = Format.TGA;

			if (GetTrimmedExtension(file2) == "dds")
				format = Format.DDS;

			if (postprocess)
				await PostProcessImage(file2.FullName, format, batchProcessing);
			else
				await ConvertImage(file2.FullName, format, false, false, true);
		}

		private static string GetTrimmedExtension(FileInfo file)
		{
			return file.Extension.ToLower().Replace(".", "");
		}

		public static async Task ConvertImages(string path, Format format, bool removeAlpha = false, bool keepExtension = false, bool delSource = true)
		{
			DirectoryInfo d = new DirectoryInfo(path);
			FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
			int i = 1;
			foreach (FileInfo file in files)
			{
				Program.mainForm.SetProgress(Program.GetPercentage(i, files.Length), "Processing " + file.Name);
				await ConvertImage(file.FullName, format, removeAlpha, keepExtension, delSource);
				i++;
			}
			Logger.Log("Done converting images");
		}

		public static async Task ConvertImage(string path, Format format, bool fillAlpha, bool keepExtension, bool deleteSource = true, string overrideOutPath = "")
		{
			MagickImage img = ImgUtils.GetMagickImage(path);
			Logger.Log("Converting " + path + " - Target Format: " + format.ToString() + " - DeleteSource: " + deleteSource + " - FillAlpha: " + fillAlpha + " - KeepExt: " + keepExtension);
			string ext = "png";
			if (format == Format.PngOpti)
			{
				img.Format = MagickFormat.Png;
				img.Quality = 70;
			}
			if (format == Format.PngFast)
			{
				img.Format = MagickFormat.Png;
				img.Quality = 20;
			}
			if (format == Format.Jpeg)
			{
				img.Format = MagickFormat.Jpeg;
				img.Quality = Config.GetInt("jpegQ");
				ext = "jpg";
			}
			if (format == Format.Weppy)
			{
				img.Format = MagickFormat.WebP;
				img.Quality = Config.GetInt("webpQ");
				ext = "webp";
			}
			if (format == Format.BMP)
			{
				img.Format = MagickFormat.Bmp;
				ext = "bmp";
			}
			if (format == Format.TGA)
			{
				img.Format = MagickFormat.Tga;
				ext = "tga";
			}
			if (format == Format.DDS)
			{
				img.Format = MagickFormat.Dds;
				ext = "dds";
				DdsCompression comp = DdsCompression.None;
				if(Config.GetBool("ddsUseDxt"))
					comp = DdsCompression.Dxt1;
				DdsWriteDefines ddsDefines = new DdsWriteDefines { Compression = comp, Mipmaps = Config.GetInt("ddsMipsAmount") };
				img.Settings.SetDefines(ddsDefines);
			}
            if (fillAlpha)
            {
				img.Settings.BackgroundColor = new MagickColor("#" + Config.Get("alphaBgColor"));
				img.Alpha(AlphaOption.Remove);
			}
			if (keepExtension)
				ext = Path.GetExtension(path).Replace(".", "");

			/*
			if (string.IsNullOrWhiteSpace(overrideOutPath) && keepExtension)
			{
				string extension = Path.GetExtension(path);
				string outPath = Path.ChangeExtension(path, null) + extension + "." + ext;
				Logger.Log("Appending old extension; writing image to " + outPath);
				img.Write(outPath);
				if (deleteSource && outPath != path)
				{
					Logger.Log("Deleting source file: " + path);
					File.Delete(path);
				}
			}
			else
			{
			*/
				string outPath = Path.ChangeExtension(path, ext);
				if (!string.IsNullOrWhiteSpace(overrideOutPath))
					outPath = overrideOutPath;
				img.Write(outPath);
				Logger.Log("Writing image to " + outPath);
				if (deleteSource && outPath != path)
				{
					Logger.Log("Deleting source file: " + path);
					File.Delete(path);
				}
			//}
			await Task.Delay(1);
		}

		public static async Task PostProcess (string path, Format format)
		{
			DirectoryInfo d = new DirectoryInfo(path);
			FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
			int i = 1;
			foreach (FileInfo file in files)
			{
				Logger.Log("Post-Processing " + file.Name);
				Program.mainForm.SetProgress(Program.GetPercentage(i, files.Length), "Processing " + file.Name);
				await PostProcessImage(file.FullName, format, false);
				i++;
			}
			Logger.Log("Done post-processing.");
		}

		public static async Task PostProcessImage (string path, Format format, bool batchProcessing = false)
		{
			Logger.Log("PostProcess: Loading MagickImage from " + path);
			MagickImage img = ImgUtils.GetMagickImage(path);
			string ext = "png";
			if (format == Format.Source)
				ext = Path.GetExtension(path).Replace(".","");
			if (format == Format.PngOpti)
			{
				img.Format = MagickFormat.Png;
				img.Quality = 70;
			}
			if (format == Format.PngFast)
			{
				img.Format = MagickFormat.Png;
				img.Quality = 20;
			}
			if (format == Format.Jpeg)
			{
				img.Format = MagickFormat.Jpeg;
				img.Quality = Config.GetInt("jpegQ");
				ext = "jpg";
			}
			if (format == Format.Weppy)
			{
				img.Format = MagickFormat.WebP;
				img.Quality = Config.GetInt("webpQ");
				ext = "webp";
			}
			if (format == Format.BMP)
			{
				img.Format = MagickFormat.Bmp;
				ext = "bmp";
			}
			if (format == Format.TGA)
			{
				img.Format = MagickFormat.Tga;
				ext = "tga";
			}
			if (!(currentScaleMode == Upscale.ScaleMode.Percent && currentScaleValue == 100))	// Skip if target scale is 100%
				img = ResizeImage(img, currentScaleValue, currentScaleMode, currentFilter, onlyDownscale);

			await Task.Delay(1);
			string outPath = Path.ChangeExtension(img.FileName, ext);

			if(Upscale.currentMode == Upscale.UpscaleMode.Batch)
				PostProcessingQueue.lastOutfile = outPath;

			if (Upscale.currentMode == Upscale.UpscaleMode.Single)
				MainUIHelper.lastOutfile = outPath;

			img.Write(outPath);

			if (outPath != path)
			{
				Logger.Log("Deleting source file: " + path);
				File.Delete(path);
			}
		}

		public static async Task PostProcessDDS (string path)
        {
			Logger.Log("PostProcess: Loading MagickImage from " + path);
			MagickImage img = ImgUtils.GetMagickImage(path);
			string ext = "dds";

			if (!(currentScaleMode == Upscale.ScaleMode.Percent && currentScaleValue == 100))   // Skip if target scale is 100%
				img = ResizeImage(img, currentScaleValue, currentScaleMode, currentFilter, onlyDownscale);

			img.Format = MagickFormat.Png00;
			img.Write(path);

			string outPath = Path.ChangeExtension(img.FileName, ext);

			await NvCompress.SaveDds(path, outPath);

			if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
				PostProcessingQueue.lastOutfile = outPath;

			if (Upscale.currentMode == Upscale.UpscaleMode.Single)
				MainUIHelper.lastOutfile = outPath;

			if (outPath != path)
			{
				Logger.Log("Deleting source file: " + path);
				File.Delete(path);
			}
		}

		public static MagickImage ResizeImage (MagickImage img, int scaleValue, Upscale.ScaleMode scaleMode, Upscale.Filter filter, bool onlyDownscale)
        {
			img.FilterType = FilterType.Mitchell;
			if(filter == Upscale.Filter.Bicubic)
				img.FilterType = FilterType.Catrom;
			if (filter == Upscale.Filter.NearestNeighbor)
				img.FilterType = FilterType.Point;

			bool heightLonger = img.Height > img.Width;
			bool widthLonger = img.Width > img.Height;
			bool square = (img.Height == img.Width);

			if (scaleMode == Upscale.ScaleMode.Percent)
			{
				Logger.Log("-> Scaling to " + scaleValue + "% with filter " + filter + "...");
				img.Resize(new Percentage(scaleValue));
				return img;
			}

			// Scale HEIGHT in the following cases:
			bool useSquare = square && scaleMode != Upscale.ScaleMode.Percent;
			bool useHeight = scaleMode == Upscale.ScaleMode.PixelsHeight;
			bool useLongerOnH = (scaleMode == Upscale.ScaleMode.PixelsLongerSide && heightLonger);
			bool useShorterOnW = (scaleMode == Upscale.ScaleMode.PixelsShorterSide && widthLonger);
			if (useSquare || useHeight || useLongerOnH || useShorterOnW)
			{
				if (onlyDownscale && (img.Height <= scaleValue))
					return img;		// Return image without scaling
				Logger.Log("-> Scaling to " + scaleValue + "px height with filter " + filter + "...");
				MagickGeometry geom = new MagickGeometry("x" + scaleValue);
				img.Resize(geom);
			}

			// Scale WIDTH in the following cases:
			bool useWidth = scaleMode == Upscale.ScaleMode.PixelsWidth;
			bool useLongerOnW = (scaleMode == Upscale.ScaleMode.PixelsLongerSide && widthLonger);
			bool useShorterOnH = (scaleMode == Upscale.ScaleMode.PixelsShorterSide && heightLonger);
			if (useWidth || useLongerOnW || useShorterOnH)
			{
				if (onlyDownscale && (img.Width <= scaleValue))
					return img;     // Return image without scaling
				Logger.Log("-> Scaling to " + scaleValue + "px width with filter " + filter + "...");
				MagickGeometry geom = new MagickGeometry(scaleValue + "x");
				img.Resize(geom);
			}

			return img;
		}
	}
}
