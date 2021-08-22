using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cupscale.Cupscale;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.Properties;
using Cupscale.UI;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
    internal class ImageProcessing
    {
        public enum Format { Source, Png50, PngFast, PngRaw, Jpeg, Weppy, BMP, TGA, DDS, GIF }

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
            {
                await PostProcessDDS(path);
                return;
            }

            if (GetTrimmedExtension(file) == "gif")
                format = Format.GIF;

            string ext = Path.GetExtension(path).ToUpper().Replace(".", "");
            if (format == Format.Png50 && ext != "PNG")
                Program.ShowMessage("Cupscale does not support the image format " + ext + " for exporting, so PNG is used.");

            if (postprocess)
                await PostProcessImage(file.FullName, format, batchProcessing);
            else
                await ConvertImage(file.FullName, format, false, ExtMode.UseNew, true);
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
            Logger.Log("[ImgProc] Done pre-processing images");
        }

        public static async Task PreProcessImage(string path, bool fillAlpha)
        {
            MagickImage img = ImgUtils.GetMagickImage(path, true);
            img.Quality = 10;

            Logger.Log("[ImgProc] Preprocessing " + path + " - Fill Alpha: " + fillAlpha);

            img = CheckColorDepth(path, img);

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
                if (Logger.doLogIo) Logger.Log("[ImgProc] Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public enum ExtMode { UseNew, KeepOld, AppendNew }
        public static async Task ConvertImage(string path, Format format, bool fillAlpha, ExtMode extMode, bool deleteSource = true, string overrideOutPath = "", bool allowTgaFlip = false)
        {
            MagickImage img = ImgUtils.GetMagickImage(path, allowTgaFlip);
            string newExt = "png";
            bool magick = true;

            Logger.Log($"[ImgProc] Converting {path} to {format}, DelSrc: {deleteSource}, Fill: {fillAlpha}, Ext: {extMode}");
            if (format == Format.PngRaw)
            {
                img.Format = MagickFormat.Png32;
                img.Quality = 0;
            }
            if (format == Format.Png50)
            {
                img.Format = MagickFormat.Png32;
                img.Quality = 50;
            }
            if (format == Format.PngFast)
            {
                img.Format = MagickFormat.Png32;
                img.Quality = 10;
            }
            if (format == Format.Jpeg)
            {
                newExt = "jpg";
                int q = Config.GetInt("jpegQ");
                if (Config.GetBool("useMozJpeg"))
                {
                    MozJpeg.Encode(path, GetOutPath(path, newExt, extMode, overrideOutPath), q);
                    magick = false;
                }
                else
                {
                    img.Format = MagickFormat.Jpeg;
                    img.Quality = q;
                }
            }
            if (format == Format.Weppy)
            {
                img.Format = MagickFormat.WebP;
                img.Quality = Config.GetInt("webpQ");
                if (img.Quality >= 100)
                    img.Settings.SetDefine(MagickFormat.WebP, "lossless", true);
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
                magick = false;
                newExt = "tga";
                await NvCompress.PngToDds(path, GetOutPath(path, newExt, ExtMode.UseNew, ""));
            }
            if (format == Format.GIF)
            {
                img.Format = MagickFormat.Gif;
            }

            if (magick)
            {
                img = CheckColorDepth(path, img);
                if (fillAlpha)
                    img = ImgUtils.FillAlphaWithBgColor(img);
            }

            string outPath = GetOutPath(path, newExt, extMode, overrideOutPath);

            if (File.Exists(outPath))
            {
                if (Logger.doLogIo) Logger.Log("[ImgProc] File exists at - making sure it doesn't have readonly flag");
                IOUtils.RemoveReadonlyFlag(outPath);
            }

            bool inPathIsOutPath = outPath.ToLower() == path.ToLower();
            if (inPathIsOutPath)    // Force overwrite by deleting source file before writing new file - THIS IS IMPORTANT
                File.Delete(path);

            if (magick)
            {
                img.Write(outPath);
                Logger.Log("[ImgProc] Written image to " + outPath);
            }
            if (deleteSource && !inPathIsOutPath)
            {
                if(Logger.doLogIo) Logger.Log("[ImgProc] Deleting source file: " + path);
                File.Delete(path);
            }
            img.Dispose();
            IOUtils.RemoveReadonlyFlag(outPath);
            await Task.Delay(1);
        }

        static string GetOutPath (string path, string newExt, ExtMode extMode, string overrideOutPath)
        {
            if (!string.IsNullOrWhiteSpace(overrideOutPath))
                return overrideOutPath;

            if (extMode == ExtMode.UseNew)
                return Path.ChangeExtension(path, newExt);

            if (extMode == ExtMode.KeepOld)
                return path;

            if (extMode == ExtMode.AppendNew)
                return path + "." + newExt;

            return null;
        }

        static MagickImage CheckColorDepth (string path, MagickImage img)
        {
            int depth = ImgUtils.GetColorDepth(path);
            Logger.Log($"[ImgProc] Color depth of {Path.GetFileName(path)} is {depth}.");

            if (depth < 24)
            {
                Logger.Log("[ImgProc] Depth is <24 - Converting to 32-bit.");
                MagickImage img32 = new MagickImage(MagickColors.Transparent, img.Width, img.Height);
                img32.Format = MagickFormat.Png32;
                img32.Composite(img, CompositeOperator.Over);
                return img32;
            }
            return img;
        }

        public static async Task PostProcessImage(string path, Format format, bool dontResize)
        {
            Logger.Log($"[ImgProc] Post-Processing {Path.GetFileName(path)} to {format}, resize: {!dontResize}");

            if (!dontResize)
                ResizeImagePost(path);

            MagickImage img = ImgUtils.GetMagickImage(path);
            string newExt = "png";
            bool magick = true;

            if (format == Format.Source)
                newExt = Path.GetExtension(path).Replace(".", "");

            if (format == Format.Png50)
            {
                img.Format = MagickFormat.Png;
                img.Quality = 50;
            }

            if (format == Format.PngFast)
            {
                img.Format = MagickFormat.Png;
                img.Quality = 10;
            }

            if (format == Format.Jpeg)
            {
                newExt = "jpg";
                int q = Config.GetInt("jpegQ");

                if (Config.GetBool("useMozJpeg"))
                {
                    MozJpeg.Encode(path, GetOutPath(path, newExt, ExtMode.UseNew, ""), q);
                    magick = false;
                }
                else
                {
                    img.Format = MagickFormat.Jpeg;
                    img.Quality = q;
                }
            }

            if (format == Format.Weppy)
            {
                img.Format = MagickFormat.WebP;
                img.Quality = Config.GetInt("webpQ");
                if(img.Quality >= 100)
                    img.Settings.SetDefine(MagickFormat.WebP, "lossless", true);
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
                magick = false;
                newExt = "tga";
                await NvCompress.PngToDds(path, GetOutPath(path, newExt, ExtMode.UseNew, ""));
            }

            if (format == Format.GIF)
            {
                img.Format = MagickFormat.Gif;
                newExt = "gif";
            }

            await Task.Delay(1);
            string outPath = GetOutPath(path, newExt, ExtMode.UseNew, "");

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
                PostProcessingQueue.lastOutfile = outPath;

            if (Upscale.currentMode == Upscale.UpscaleMode.Single || Upscale.currentMode == Upscale.UpscaleMode.Composition)
                PreviewUI.lastOutfile = outPath;

            if (magick)
            {
                img.Write(outPath);
                Logger.Log("[ImgProc] Written image to " + outPath);
            }

            if (outPath.ToLower() != path.ToLower())
            {
                if (Logger.doLogIo) Logger.Log("[ImgProc] Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public static async Task PostProcessDDS(string path)
        {
            Logger.Log("[ImgProc] PostProcessDDS: Loading MagickImage from " + path);
            MagickImage img = ImgUtils.GetMagickImage(path);
            string ext = "dds";

            img = ResizeImagePostMagick(img);

            img.Format = MagickFormat.Png00;
            img.Write(path);

            string outPath = Path.ChangeExtension(img.FileName, ext);

            await NvCompress.PngToDds(path, outPath);

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
                PostProcessingQueue.lastOutfile = outPath;

            if (Upscale.currentMode == Upscale.UpscaleMode.Single || Upscale.currentMode == Upscale.UpscaleMode.Composition)
                PreviewUI.lastOutfile = outPath;

            if (outPath.ToLower() != path.ToLower())
            {
                if (Logger.doLogIo) Logger.Log("[ImgProc] Deleting source file: " + path);
                File.Delete(path);
            }
        }

        public static MagickImage ResizeImagePre(MagickImage img)
        {
            if (!(preScaleMode == Upscale.ScaleMode.Percent && preScaleValue == 100))   // Skip if target scale is 100%
            {
                img = ResizeImageAdvancedMagick(img, preScaleValue, preScaleMode, preFilter, preOnlyDownscale);
                Logger.Log("[ImgProc] ResizeImagePre: Resized to " + img.Width + "x" + img.Height);
            }
            return img;
        }

        public static MagickImage ResizeImagePostMagick(MagickImage img)
        {
            if (!(postScaleMode == Upscale.ScaleMode.Percent && postScaleValue == 100))   // Skip if target scale is 100%
            {
                img = ResizeImageAdvancedMagick(img, postScaleValue, postScaleMode, postFilter, postOnlyDownscale);
                Logger.Log("[ImgProc] ResizeImagePost: Resized to " + img.Width + "x" + img.Height);
            }
            return img;
        }

        public static void ResizeImagePost(string path)
        {
            if (!(postScaleMode == Upscale.ScaleMode.Percent && postScaleValue == 100))   // Skip if target scale is 100%
            {
                ImgSharpUtils.ResizeImageAdvanced(path, postScaleValue, postScaleMode, postFilter, postOnlyDownscale);
                Logger.Log("[ImgProc] ResizeImagePost: Resized using ImageSharp");
            }
        }



        public static MagickImage ResizeImageAdvancedMagick(MagickImage img, int scaleValue, Upscale.ScaleMode scaleMode, Upscale.Filter filter, bool onlyDownscale)
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
                Logger.Log("[ImgProc] Scaling to " + scaleValue + "% with filter " + filter + "...");
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
                Logger.Log("[ImgProc] Scaling to " + scaleValue + "px height with filter " + filter + "...");
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
                Logger.Log("[ImgProc] Scaling to " + scaleValue + "px width with filter " + filter + "...");
                MagickGeometry geom = new MagickGeometry(scaleValue + "x");
                img.Resize(geom);
            }

            return img;
        }
    }
}
