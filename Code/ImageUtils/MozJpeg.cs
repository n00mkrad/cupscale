using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class MozJpeg
    {
        public static void Encode(string inPath, string outPath, int q, bool chromaSubSample = true)
        {
            try
            {
                using var bmp = new Bitmap(inPath);
                using var tjc = new MozJpegSharp.TJCompressor();
                byte[] compressed;
                MozJpegSharp.TJSubsamplingOption subSample = MozJpegSharp.TJSubsamplingOption.Chrominance420;
                if (!chromaSubSample)
                    subSample = MozJpegSharp.TJSubsamplingOption.Chrominance444;
                compressed = tjc.Compress(bmp, subSample, q, MozJpegSharp.TJFlags.None);
                File.WriteAllBytes(outPath, compressed);
                Logger.Log("[MozJpeg] Written image to " + outPath);
            }
            catch (Exception e)
            {
                Logger.ErrorMessage("MozJpeg Error: ", e);
            }
        }
    }
}
