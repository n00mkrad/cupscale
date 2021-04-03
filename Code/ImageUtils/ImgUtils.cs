using DdsFileTypePlus;
using ImageMagick;
using Microsoft.WindowsAPICodePack.Shell;
using PaintDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Cupscale.ImageUtils
{
    class ImgUtils
    {
        public static Image GetImage(string path)
        {
            if (Logger.doLogIo) Logger.Log("[ImgUtils] Reading Image from " + path);
            using MemoryStream stream = new MemoryStream(File.ReadAllBytes(path));
            Image img = Image.FromStream(stream);
            if (Logger.doLogIo) Logger.Log("[OK]", true, true);
            return img;
        }

        public static MagickImage GetMagickImage(string path, bool allowTgaFlip = false)
        {
            if (Logger.doLogIo) Logger.Log("[ImgUtils] Reading MagickImage from " + path);
            MagickImage image;
            if (Path.GetExtension(path).ToLower() == ".dds")
            {
                try
                {
                    image = new MagickImage(path);      // Try reading DDS with IM, fall back to DdsFileTypePlusHack if it fails
                }
                catch (Exception magickEx)
                {
                    Logger.Log($"[ImgUtils] Failed to read DDS using Magick.NET ({magickEx.Message}) - Trying DdsFileTypePlusHack");
                    try
                    {
                        Surface surface = DdsFile.Load(path);
                        image = ConvertToMagickImage(surface);
                        image.HasAlpha = DdsFile.HasTransparency(surface);
                    }
                    catch (Exception ddsEx)
                    {
                        Logger.ErrorMessage("[ImgUtils] This DDS format appears to be incompatible.", ddsEx);
                        return null;
                    }
                }
            }
            else
            {
                image = new MagickImage(path);
            }
            if (allowTgaFlip && Path.GetExtension(path).ToLower() == ".tga" && Config.GetBool("flipTga"))
            {
                image.Flip();
                if (Logger.doLogIo) Logger.Log("[Flipped TGA]", true, true);
            }
            if (Logger.doLogIo) Logger.Log("[OK]", true, true);
            return image;
        }

        public static MagickImage ConvertToMagickImage(Surface surface)
        {
            MagickImage result;
            Bitmap bitmap = surface.CreateAliasedBitmap();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Position = 0;
                result = new MagickImage(memoryStream, new MagickReadSettings() { Format = MagickFormat.Png00 });
            }
            return result;
        }

        public static float GetScale(Image imgFrom, Image imgTo)
        {
            return (int)Math.Round(GetScaleFloat(imgFrom, imgTo));
        }

        public static float GetScaleFloat(Image imgFrom, Image imgTo)
        {
            return (float)imgTo.Width / (float)imgFrom.Width;
        }

        public static MagickImage FillAlphaWithBgColor(MagickImage img)
        {
            return FillAlphaWithColor(img, new MagickColor("#" + Config.Get("alphaBgColor")));
        }

        public static MagickImage FillAlphaWithColor(MagickImage img, MagickColor color)
        {
            MagickImage bg = new MagickImage(color, img.Width, img.Height);
            bg.BackgroundColor = color;
            bg.Composite(img, CompositeOperator.Over);

            return bg;
        }

        public static int GetColorDepth(string path)
        {
            try
            {
                ShellFile shellFile = ShellFile.FromFilePath(path);
                int depth = (int)shellFile.Properties.System.Image.BitDepth.Value;
                return depth;
                //MemoryStream stream = new MemoryStream(File.ReadAllBytes(path));
                //var source = BitmapFrame.Create(stream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.OnDemand);
                //return source.Format.BitsPerPixel;
            }
            catch (Exception e)
            {
                Logger.Log("[ImgUtils] Failed to read color depth: " + e.Message + " - Defaulting to 32.");
                return 32;
            }
        }

        public static MagickImage MergeImages(string[] imgs, bool vertically, bool deleteSourceImgs)
        {
            MagickImageCollection collection = new MagickImageCollection();

            foreach (string img in imgs)
            {
                collection.Add(img);
                if (deleteSourceImgs)
                    File.Delete(img);
            }

            if (!vertically)
                return (MagickImage)collection.AppendHorizontally();
            else
                return (MagickImage)collection.AppendVertically();
        }
    }
}
