using Cupscale.Main;
using Cupscale.UI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class ImgSharpUtils
    {
        public static void Resize (string path, float scaleFactor, IResampler filter)
        {
            Image img = Image.Load(path);
            int w = (int)Math.Round(img.Width * scaleFactor);
            int h = (int)Math.Round(img.Height * scaleFactor);
            img.Mutate(x => x.Resize(w, h, filter));
            img.Save(path);
        }

        public static void Resize(Image img, string outpath, float scaleFactor, IResampler filter)
        {
            int w = (int)Math.Round(img.Width * scaleFactor);
            int h = (int)Math.Round(img.Height * scaleFactor);
            img.Mutate(x => x.Resize(w, h, filter));
            img.Save(outpath);
        }

        public static void ResizeImageAdvanced(string path, int scaleValue, Upscale.ScaleMode scaleMode, Upscale.Filter filter, bool onlyDownscale, bool raw = true)
        {
            Image img = Image.Load(path);
            ResizeImageAdvanced(img, path, scaleValue, scaleMode, filter, onlyDownscale, raw);
        }

        public static void ResizeImageAdvanced(Image img, string outpath, int scaleValue, Upscale.ScaleMode scaleMode, Upscale.Filter filter, bool onlyDownscale, bool raw = true)
        {
            PngEncoder enc = new PngEncoder();
            enc.CompressionLevel = PngCompressionLevel.DefaultCompression;
            if (raw) enc.CompressionLevel = PngCompressionLevel.NoCompression;
            IResampler resampler;
            resampler = KnownResamplers.MitchellNetravali;
            if (filter == Upscale.Filter.Bicubic)
                resampler = KnownResamplers.Bicubic;
            if (filter == Upscale.Filter.Nearest)
                resampler = KnownResamplers.NearestNeighbor;

            bool heightLonger = img.Height > img.Width;
            bool widthLonger = img.Width > img.Height;
            bool square = (img.Height == img.Width);

            if (scaleMode == Upscale.ScaleMode.Percent)
            {
                Logger.Log("[ImgSharp] Scaling to " + scaleValue + "% with filter " + filter + "...");
                img.Mutate(x => x.Resize((img.Width * scaleValue / 100f).RoundToInt(), (img.Height * scaleValue / 100f).RoundToInt(), resampler));
                img.Save(outpath, enc);
                return;
            }

            // Scale HEIGHT in the following cases:
            bool useSquare = square && scaleMode != Upscale.ScaleMode.Percent;
            bool useHeight = scaleMode == Upscale.ScaleMode.PixelsHeight;
            bool useLongerOnH = (scaleMode == Upscale.ScaleMode.PixelsLongerSide && heightLonger);
            bool useShorterOnW = (scaleMode == Upscale.ScaleMode.PixelsShorterSide && widthLonger);
            if (useSquare || useHeight || useLongerOnH || useShorterOnW)
            {
                if (onlyDownscale && (img.Height <= scaleValue))
                    return;     // don't scale
                Logger.Log("[ImgSharp] Scaling to " + scaleValue + "px height with filter " + filter + "...");
                float wFactor = (float)scaleValue / img.Height;
                img.Mutate(x => x.Resize((img.Width * wFactor).RoundToInt(), scaleValue, resampler));
                img.Save(outpath, enc);
                return;
            }

            // Scale WIDTH in the following cases:
            bool useWidth = scaleMode == Upscale.ScaleMode.PixelsWidth;
            bool useLongerOnW = (scaleMode == Upscale.ScaleMode.PixelsLongerSide && widthLonger);
            bool useShorterOnH = (scaleMode == Upscale.ScaleMode.PixelsShorterSide && heightLonger);
            if (useWidth || useLongerOnW || useShorterOnH)
            {
                if (onlyDownscale && (img.Width <= scaleValue))
                    return;     // don't scale
                Logger.Log("[ImgSharp] Scaling to " + scaleValue + "px width with filter " + filter + "...");
                float hFactor = (float)scaleValue / img.Width;
                img.Mutate(x => x.Resize(scaleValue, (img.Height * hFactor).RoundToInt(), resampler));
                img.Save(outpath, enc);
                return;
            }
        }
    }
}
