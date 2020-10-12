using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Cupscale.Cupscale;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.Properties;
using Cupscale.UI;
using ImageMagick;
using ImageMagick.Formats.Bmp;
using ImageMagick.Formats.Dds;
using ImageMagick.Formats.Png;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
    internal class ImageProcessing
    {
        public enum Format { Source, Png50, PngFast, PngRaw, Jpeg, Weppy, BMP, TGA, DDS }

        public static Upscale.Filter postFilter = Upscale.Filter.Mitchell;
        public static Upscale.ScaleMode postScaleMode = Upscale.ScaleMode.Percent;
        public static int postScaleValue = 100;
        public static bool postOnlyDownscale = true;

        public static Upscale.Filter preFilter = Upscale.Filter.Mitchell;
        public static Upscale.ScaleMode preScaleMode = Upscale.ScaleMode.Percent;
        public static int preScaleValue = 100;
        public static bool preOnlyDownscale = true;

        public static async Task ConvertImageToOriginalFormat(string path, bool postprocess, bool batchProcessing, bool setProgress = true)
        {
            FileInfo file = new FileInfo(path);

            Format format = Format.Png50;

            if (GetTrimmedExtension(file) == "jpg" || GetTrimmedExtension(file) == "jpeg")
                format = Format.Jpeg;

            if (GetTrimmedExtension(file) == "webp")
                format = Format.Weppy;

            if (GetTrimmedExtension(file) == "bmp")
                format = Format.BMP;

            if (GetTrimmedExtension(file) == "tga")
                format = Format.TGA;

            if (GetTrimmedExtension(file) == "dds")
                format = Format.DDS;

            if (postprocess)
                await PostProcessImage(file.FullName, format, batchProcessing);
            else
                await ConvertImage(file.FullName, format, false, ExtensionMode.UseNew, true);
        }

        private static string GetTrimmedExtension(FileInfo file)
        {
            return file.Extension.ToLower().Replace(".", "");
        }

        public static async Task PreProcessImages(string path, bool fillAlpha)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            int i = 1;
            foreach (FileInfo file in files)
            {
                Program.mainForm.SetProgress(Program.GetPercentage(i, files.Length), "Converting " + file.Name);
                await PreProcessImage(file.FullName, fillAlpha);
                i++;
            }
            Logger.Log("Done pre-processing images");
        }

        public static async Task PreProcessImage(string path, bool fillAlpha)
        {
            MagickImage img = ImgUtils.GetMagickImage(path);
            img.Quality = 20;

            Logger.Log("Preprocessing " + path + " - Fill Alpha: " + fillAlpha);

            if (fillAlpha)
                img = ImgUtils.FillAlphaWithBgColor(img);

            img = ResizeImagePre(img);

            string outPath = path + ".png";
            await Task.Delay(1);
            img.Format = MagickFormat.Png32;

            if (outPath.ToLower() == path.ToLower())    // Force overwrite by deleting source file before writing new file - THIS IS IMPORTANT
                File.Delete(path);

            img.Write(outPath);

            if (outPath.ToLower() != path.ToLower())
            {
                Logger.Log("Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public enum ExtensionMode { UseNew, KeepOld, AppendNew }
        public static async Task ConvertImage(string path, Format format, bool fillAlpha, ExtensionMode extMode, bool deleteSource = true, string overrideOutPath = "")
        {
            MagickImage img = ImgUtils.GetMagickImage(path);

            Logger.Log("Converting " + path + " - Target Format: " + format.ToString() + " - DeleteSource: " + deleteSource + " - FillAlpha: " + fillAlpha + " - ExtMode: " + extMode.ToString() + " - outpath: " + overrideOutPath);
            string newExt = "png";
            if (format == Format.PngRaw)
            {
                img.Format = GetPngFormat(path);
                img.Quality = 0;
            }
            if (format == Format.Png50)
            {
                img.Format = GetPngFormat(path);
                img.Quality = 50;
            }
            if (format == Format.PngFast)
            {
                img.Format = GetPngFormat(path);
                img.Quality = 20;
            }
            if (format == Format.Jpeg)
            {
                img.Format = MagickFormat.Jpeg;
                img.Quality = Config.GetInt("jpegQ");
                newExt = "jpg";
            }
            if (format == Format.Weppy)
            {
                img.Format = MagickFormat.WebP;
                img.Quality = Config.GetInt("webpQ");
                newExt = "webp";
            }
            if (format == Format.BMP)
            {
                img.Format = MagickFormat.Bmp;
                newExt = "bmp";
            }
            if (format == Format.TGA)
            {
                img.Format = MagickFormat.Tga;
                newExt = "tga";
            }
            if (format == Format.DDS)
            {
                img.Format = MagickFormat.Dds;
                newExt = "dds";
                DdsCompression comp = DdsCompression.None;
                if (Config.GetBool("ddsUseDxt"))
                    comp = DdsCompression.Dxt1;
                DdsWriteDefines ddsDefines = new DdsWriteDefines { Compression = comp, Mipmaps = Config.GetInt("ddsMipsAmount") };
                img.Settings.SetDefines(ddsDefines);
            }

            if (fillAlpha)
                img = ImgUtils.FillAlphaWithBgColor(img);

            string outPath = null;

            if (extMode == ExtensionMode.UseNew)
                outPath = Path.ChangeExtension(path, newExt);

            if (extMode == ExtensionMode.KeepOld)
                outPath = path;

            if (extMode == ExtensionMode.AppendNew)
                outPath = path + "." + newExt;

            if (!string.IsNullOrWhiteSpace(overrideOutPath))
                outPath = overrideOutPath;

            bool inPathIsOutPath = outPath.ToLower() == path.ToLower();
            if (inPathIsOutPath)    // Force overwrite by deleting source file before writing new file - THIS IS IMPORTANT
                File.Delete(path);                

            img.Write(outPath);
            Logger.Log("Writing image to " + outPath);
            if (deleteSource && !inPathIsOutPath)
            {
                Logger.Log("Deleting source file: " + path);
                File.Delete(path);
            }
            await Task.Delay(1);
        }

        static MagickFormat GetPngFormat (string path)
        {
            int depth = ImgUtils.GetColorDepth(path);
            if (depth < 24)
            {
                Logger.Log($"Color depth of {Path.GetFileName(path)} is {depth}, using Png24 format");
                return MagickFormat.Png24;
            }
            else
            {
                Logger.Log($"Color depth of {Path.GetFileName(path)} is {depth}, using Png32 format for alpha support");
                return MagickFormat.Png32;
            }
        }

        public static async Task PostProcessImage(string path, Format format, bool dontResize)
        {
            MagickImage img = ImgUtils.GetMagickImage(path);
            string ext = "png";
            if (format == Format.Source)
                ext = Path.GetExtension(path).Replace(".", "");
            if (format == Format.Png50)
            {
                img.Format = MagickFormat.Png;
                img.Quality = 50;
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

            if(!dontResize)
                img = ResizeImagePost(img);

            await Task.Delay(1);
            string outPath = Path.ChangeExtension(img.FileName, ext);

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
                PostProcessingQueue.lastOutfile = outPath;

            if (Upscale.currentMode == Upscale.UpscaleMode.Single)
                MainUIHelper.lastOutfile = outPath;

            Logger.Log("Writing image as " + img.Format + " to " + outPath);
            img.Write(outPath);

            if (outPath.ToLower() != path.ToLower())
            {
                Logger.Log("Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public static async Task PostProcessDDS(string path)
        {
            Logger.Log("PostProcess: Loading MagickImage from " + path);
            MagickImage img = ImgUtils.GetMagickImage(path);
            string ext = "dds";

            img = ResizeImagePost(img);

            img.Format = MagickFormat.Png00;
            img.Write(path);

            string outPath = Path.ChangeExtension(img.FileName, ext);

            await NvCompress.SaveDds(path, outPath);

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
                PostProcessingQueue.lastOutfile = outPath;

            if (Upscale.currentMode == Upscale.UpscaleMode.Single)
                MainUIHelper.lastOutfile = outPath;

            if (outPath.ToLower() != path.ToLower())
            {
                Logger.Log("Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public static MagickImage ResizeImagePre(MagickImage img)
        {
            if (!(preScaleMode == Upscale.ScaleMode.Percent && preScaleValue == 100))   // Skip if target scale is 100%
            {
                img = ResizeImage(img, preScaleValue, preScaleMode, preFilter, preOnlyDownscale);
                Logger.Log("ResizeImagePre: Resized to " + img.Width + "x" + img.Height);
            }
            else
            {
                Logger.Log("ResizeImagePre: Skipped resize because it's set to 100%.");
            }
            return img;
        }

        public static MagickImage ResizeImagePost(MagickImage img)
        {
            if (!(postScaleMode == Upscale.ScaleMode.Percent && postScaleValue == 100))   // Skip if target scale is 100%
            {
                img = ResizeImage(img, postScaleValue, postScaleMode, postFilter, postOnlyDownscale);
                Logger.Log("ResizeImagePost: Resized to " + img.Width + "x" + img.Height);
            }
            else
            {
                Logger.Log("ResizeImagePost: Skipped resize because it's set to 100%.");
            }
            return img;
        }

        public static MagickImage ResizeImage(MagickImage img, int scaleValue, Upscale.ScaleMode scaleMode, Upscale.Filter filter, bool onlyDownscale)
        {
            img.FilterType = FilterType.Mitchell;
            if (filter == Upscale.Filter.Bicubic)
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
                    return img;     // Return image without scaling
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
