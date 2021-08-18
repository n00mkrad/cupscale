using System;
using Cupscale.UI;
using System.IO;

namespace Cupscale.IO
{
	internal class Paths
	{
		public static string binPath;
		public static string defaultModelPath;
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

		public static void Init()
		{
			binPath = Path.Combine(GetDataPath(), "bin");

			defaultModelPath = Path.Combine(GetDataPath(), "models");
			Directory.CreateDirectory(defaultModelPath);

			previewPath = Path.Combine(GetDataPath(), "preview");
			Directory.CreateDirectory(previewPath);

			previewOutPath = Path.Combine(GetDataPath(), "preview-out");
			Directory.CreateDirectory(previewOutPath);

			imgInPath = Path.Combine(GetDataPath(), "img-in");
			Directory.CreateDirectory(imgInPath);

			imgOutPath = Path.Combine(GetDataPath(), "img-out");
			Directory.CreateDirectory(imgOutPath);

			imgOutNcnnPath = Path.Combine(GetDataPath(), "img-out-ncnn");
			Directory.CreateDirectory(imgOutNcnnPath);

			tempImgPath = Path.Combine(GetDataPath(), "loaded-img", "temp.png");
			Directory.CreateDirectory(tempImgPath.GetParentDir());

			clipboardFolderPath = Path.Combine(GetDataPath(), "clipboard");
			Directory.CreateDirectory(clipboardFolderPath);

			presetsPath = Path.Combine(GetDataPath(), "model-presets");
			Directory.CreateDirectory(presetsPath);

			compositionOut = Path.Combine(GetDataPath(), "composition");
			Directory.CreateDirectory(compositionOut);

			framesOutPath = Path.Combine(GetDataPath(), "frames-out");
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
