using Cupscale.UI;
using System.IO;

namespace Cupscale.IO
{
	internal class Paths
	{
		public static string esrganPath;
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
		public static string progressLogfile;

		public static void Init()
		{
			esrganPath = Path.Combine(Config.Get("modelPath"), "ShippedEsrgan");
			previewPath = Path.Combine(Config.Get("modelPath"), "preview");
			previewOutPath = Path.Combine(Config.Get("modelPath"), "preview-out");
			imgInPath = Path.Combine(Config.Get("modelPath"), "img-in");
			imgOutPath = Path.Combine(Config.Get("modelPath"), "img-out");
			imgOutNcnnPath = Path.Combine(Config.Get("modelPath"), "img-out-ncnn");
			tempImgPath = Path.Combine(Config.Get("modelPath"), "loaded-img", "temp.png");
			clipboardFolderPath = Path.Combine(Config.Get("modelPath"), "clipboard");
			presetsPath = Path.Combine(Config.Get("modelPath"), "model-presets");
			compositionOut = Path.Combine(Config.Get("modelPath"), "composition");
			framesOutPath = Path.Combine(Config.Get("modelPath"), "frames-out");
			progressLogfile = Path.Combine(esrganPath, "prog");
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
	}
}
