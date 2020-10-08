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
		//public static string convertTempPath;
		public static string progressLogfile;

		public static void Init()
		{
			esrganPath = Path.Combine(IOUtils.GetAppDataDir(), "ShippedEsrgan");
			previewPath = Path.Combine(IOUtils.GetAppDataDir(), "preview");
			previewOutPath = Path.Combine(IOUtils.GetAppDataDir(), "preview-out");
			imgInPath = Path.Combine(IOUtils.GetAppDataDir(), "img-in");
			imgOutPath = Path.Combine(IOUtils.GetAppDataDir(), "img-out");
			imgOutNcnnPath = Path.Combine(IOUtils.GetAppDataDir(), "img-out-ncnn");
			//convertTempPath = Path.Combine(IOUtils.GetAppDataDir(), "convert-temp");
			tempImgPath = Path.Combine(IOUtils.GetAppDataDir(), "loaded-img", "temp.png");
			clipboardFolderPath = Path.Combine(IOUtils.GetAppDataDir(), "clipboard");
			presetsPath = Path.Combine(IOUtils.GetAppDataDir(), "model-presets");
			progressLogfile = Path.Combine(esrganPath, "prog");
			Directory.CreateDirectory(previewPath);
			Directory.CreateDirectory(previewOutPath);
			Directory.CreateDirectory(imgInPath);
			Directory.CreateDirectory(imgOutPath);
			Directory.CreateDirectory(imgOutNcnnPath);
			Directory.CreateDirectory(tempImgPath.GetParentDir());
			Directory.CreateDirectory(clipboardFolderPath);
			Directory.CreateDirectory(presetsPath);
		}
	}
}
