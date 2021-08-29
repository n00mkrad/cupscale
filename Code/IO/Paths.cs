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
		public static string tempImgPath;
		public static string clipboardFolderPath;
		public static string presetsPath;
		public static string compositionOut;
		public static string framesOutPath;

		public static readonly string pythonTuringUrl = "https://dl.nmkd-hz.de/flowframes/setupfiles/py-tu/v1/py-tu.7z";
		public static readonly string pythonAmpereUrl = "https://dl.nmkd-hz.de/flowframes/setupfiles/py-amp/v1/py-amp.7z";

		public static readonly string ncnnMdlDir = ".ncnn-models";

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

            if (IoUtils.IsPortable())
            {
                if (!IoUtils.hasShownPortableInfo)
                {
                    Logger.Log("Running in portable mode. Data folder: " + Path.Combine(GetExeDir(), "CupscaleData"), false);
                    IoUtils.hasShownPortableInfo = true;
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

		public static string GetAiDir (Implementations.Implementation impl)
        {
			return Path.Combine(binPath, impl.dir);
        }
    }
}
