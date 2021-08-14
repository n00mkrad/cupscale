using System;
using Cupscale.UI;
using System.IO;

namespace Cupscale.IO
{
	internal class Paths
	{
		public static string implementationsPath;
		public static string previewPath;
		public static string previewOutPath;
		public static string imgInPath;
		public static string imgOutPath;
		public static string imgOutNcnnPath;
		public static string tempImgPath;
		public static string clipboardFolderPath;
		public static string presetsPath;
		public static string compositionOut;
		public static string framesOutPath;
		//public static string convertTempPath;

		public static void Init()
		{
			implementationsPath = Path.Combine(GetDataPath(), "implementations");
			previewPath = Path.Combine(GetDataPath(), "preview");
			previewOutPath = Path.Combine(GetDataPath(), "preview-out");
			imgInPath = Path.Combine(GetDataPath(), "img-in");
			imgOutPath = Path.Combine(GetDataPath(), "img-out");
			imgOutNcnnPath = Path.Combine(GetDataPath(), "img-out-ncnn");
			tempImgPath = Path.Combine(GetDataPath(), "loaded-img", "temp.png");
			clipboardFolderPath = Path.Combine(GetDataPath(), "clipboard");
			presetsPath = Path.Combine(GetDataPath(), "model-presets");
			compositionOut = Path.Combine(GetDataPath(), "composition");
			framesOutPath = Path.Combine(GetDataPath(), "frames-out");
			Directory.CreateDirectory(previewPath);
			Directory.CreateDirectory(previewOutPath);
			Directory.CreateDirectory(imgInPath);
			Directory.CreateDirectory(imgOutPath);
			Directory.CreateDirectory(imgOutNcnnPath);
			Directory.CreateDirectory(tempImgPath.GetParentDir());
			Directory.CreateDirectory(clipboardFolderPath);
			Directory.CreateDirectory(presetsPath);
			Directory.CreateDirectory(compositionOut);
			Directory.CreateDirectory(framesOutPath);
		}

        public static string GetDataPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(path, "Cupscale");

            if (IOUtils.IsPortable())
            {
                if (!IOUtils.hasShownPortableInfo)
                {
                    Logger.Log("Running in portable mode. Data folder: " + Path.Combine(GetExeDir(), "CupscaleData"), false);
                    IOUtils.hasShownPortableInfo = true;
                }
                path = Path.Combine(GetExeDir(), "CupscaleData");
            }

            Directory.CreateDirectory(path);
            return path;
        }

        public static string GetExeDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
