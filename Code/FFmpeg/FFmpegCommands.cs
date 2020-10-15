using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale
{
    class FFmpegCommands
    {
        public static async Task VideoToFrames(string inputFile, string frameFolderPath, bool deDupe, bool hdr, bool delSrc)
        {
            if (!Directory.Exists(frameFolderPath))
                Directory.CreateDirectory(frameFolderPath);
            string hdrStr = "";
            if (hdr) hdrStr = FFmpegStrings.hdrFilter;
            string deDupeStr = "";
            if (deDupe) deDupeStr = "-vf mpdecimate";
            string args = "-i \"" + inputFile + "\" " + hdrStr + " -vsync 0 " + deDupeStr + " \"" + frameFolderPath + "/%04d.png\"";
            await FFmpeg.Run(args);
            await Task.Delay(1);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static async void ExtractSingleFrame(string inputFile, int frameNum, bool hdr, bool delSrc)
        {
            string hdrStr = "";
            if (hdr) hdrStr = FFmpegStrings.hdrFilter;
            string args = "-i " + inputFile.Wrap() + " " + hdrStr
                + " -vf \"select=eq(n\\," + frameNum + ")\" -vframes 1  " + inputFile.Wrap() + "-frame" + frameNum + ".png";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static async Task FramesToMp4 (string inputDir, bool useH265, int crf, int fps, string prefix, bool delSrc)
        {
            int nums = IOUtils.GetFilenameCounterLength(Directory.GetFiles(inputDir, "*.png")[0], prefix);
            string enc = "libx264";
            if (useH265) enc = "libx265";
            string args = " -framerate " + fps + " -i \"" + inputDir + "\\" + prefix + "%0" + nums + "d.png\" -c:v " + enc
                + " -crf " + crf + " -pix_fmt yuv420p -movflags +faststart -vf \"crop = trunc(iw / 2) * 2:trunc(ih / 2) * 2\"  -c:a copy \"" + inputDir + ".mp4\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputDir); // CHANGE CODE TO BE ABLE TO DELETE DIRECTORIES!!
        }

        public static async Task FramesToOneFpsMp4(string inputDir, bool useH265, int crf, int loopTimes, string prefix, bool delSrc)
        {
            int nums = IOUtils.GetFilenameCounterLength(Directory.GetFiles(inputDir, "*.png")[0], prefix);
            string enc = "libx264";
            if (useH265) enc = "libx265";
            string args = " -framerate 1 -stream_loop " + loopTimes + " -i \"" + inputDir + "\\" + prefix + "%0" + nums + "d.png\" -c:v " + enc + " -r 30"
                + " -crf " + crf + " -pix_fmt yuv420p -movflags +faststart -vf \"crop = trunc(iw / 2) * 2:trunc(ih / 2) * 2\"  -c:a copy \"" + inputDir + ".mp4\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputDir); // CHANGE CODE TO BE ABLE TO DELETE DIRECTORIES!!
        }

        public static async Task FramesToMp4Looped(string inputDir, bool useH265, int crf, int fps, int loopTimes, string prefix, bool delSrc)
        {
            int nums = IOUtils.GetFilenameCounterLength(Directory.GetFiles(inputDir, "*.png")[0], prefix);
            string enc = "libx264";
            if (useH265) enc = "libx265";
            string args = " -framerate " + fps + " -stream_loop " + loopTimes + " -i \"" + inputDir + "\\" + prefix + "%0" + nums + "d.png\" -c:v " + enc
                + " -crf " + crf + " -pix_fmt yuv420p -movflags +faststart -vf \"crop = trunc(iw / 2) * 2:trunc(ih / 2) * 2\"  -c:a copy \"" + inputDir + ".mp4\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputDir); // CHANGE CODE TO BE ABLE TO DELETE DIRECTORIES!!
        }

        public static async void FramesToApng (string inputDir, bool opti, int fps, string prefix, bool delSrc)
        {
            int nums = IOUtils.GetFilenameCounterLength(Directory.GetFiles(inputDir, "*.png")[0], prefix);
            string filter = "";
            if(opti) filter = "-vf \"split[s0][s1];[s0]palettegen[p];[s1][p]paletteuse\"";
            string args = "-framerate " + fps + " -i \"" + inputDir + "\\" + prefix + "%0" + nums + "d.png\" -f apng -plays 0 " + filter + " \"" + inputDir + "-anim.png\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputDir); // CHANGE CODE TO BE ABLE TO DELETE DIRECTORIES!!
        }

        public static async Task FramesToGif (string inputDir, bool opti, int fps, string prefix, bool delSrc)
        {
            int nums = IOUtils.GetFilenameCounterLength(Directory.GetFiles(inputDir, "*.png")[0], prefix);
            string filter = "";
            if (opti) filter = "-vf \"split[s0][s1];[s0]palettegen[p];[s1][p]paletteuse\"";
            string args = "-framerate " + fps + " -i \"" + inputDir + "\\" + prefix + "%0" + nums + "d.png\" -f gif " + filter + " \"" + inputDir + ".gif\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputDir); // CHANGE CODE TO BE ABLE TO DELETE DIRECTORIES!!
        }

        public static async Task LoopVideo (string inputFile, int times, bool delSrc)
        {
            string pathNoExt = Path.ChangeExtension(inputFile, null);
            string ext = Path.GetExtension(inputFile);
            string args = " -stream_loop " + times + " -i \"" + inputFile + "\"  -c copy \"" + pathNoExt + "-" + times + "xLoop" + ext + "\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static async Task LoopVideoEnc (string inputFile, int times, bool useH265, int crf, bool delSrc)
        {
            string pathNoExt = Path.ChangeExtension(inputFile, null);
            string ext = Path.GetExtension(inputFile);
            string enc = "libx264";
            if (useH265) enc = "libx265";
            string args = " -stream_loop " + times + " -i \"" + inputFile +  "\"  -c:v " + enc + " -crf " + crf + " -c:a copy \"" + pathNoExt + "-" + times + "xLoop" + ext + "\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static async Task ChangeSpeed (string inputFile, float newSpeedPercent, bool delSrc)
        {
            string pathNoExt = Path.ChangeExtension(inputFile, null);
            string ext = Path.GetExtension(inputFile);
            float val = newSpeedPercent / 100f;
            string speedVal = (1f / val).ToString("0.0000").Replace(",", ".");
            string args = " -itsscale " + speedVal + " -i \"" + inputFile + "\"  -c copy \"" + pathNoExt + "-" + newSpeedPercent + "pcSpeed" + ext + "\"";
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static async Task Encode (string inputFile, string vcodec, string acodec, int crf, int audioKbps, bool delSrc)
        {
            string args = " -i \"INPATH\" -c:v VCODEC -crf CRF -pix_fmt yuv420p -c:a ACODEC -b:a ABITRATE \"OUTPATH\"";
            if (string.IsNullOrWhiteSpace(acodec))
                args = args.Replace("-c:a", "-an");
            args = args.Replace("VCODEC", vcodec);
            args = args.Replace("ACODEC", acodec);
            args = args.Replace("CRF", crf.ToString());
            if(audioKbps > 0)
                args = args.Replace("ABITRATE", audioKbps.ToString());
            else
                args = args.Replace(" -b:a ABITRATE", "");
            string filenameNoExt = Path.ChangeExtension(inputFile, null);
            args = args.Replace("INPATH", inputFile);
            args = args.Replace("OUTPATH", filenameNoExt + "-convert.mp4");
            await FFmpeg.Run(args);
            if (delSrc)
                DeleteSource(inputFile);
        }

        public static float GetFramerate (string inputFile)
        {
            string args = " -i \"INPATH\"";
            args = args.Replace("INPATH", inputFile);
            string ffmpegOut = FFmpeg.RunAndGetOutput(args);
            string[] entries = ffmpegOut.Split(',');
            foreach(string entry in entries)
            {
                if (entry.Contains(" fps"))
                {
                    string num = entry.Replace(" fps", "").Trim().Replace(",", ".");
                    float value;
                    float.TryParse(num, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                    return value;
                }
            }
            return 0f;
        }

        static void DeleteSource (string path)
        {
            Logger.Log("Deleting input file: " + path);
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
