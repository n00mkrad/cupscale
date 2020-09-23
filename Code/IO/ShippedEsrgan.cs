using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Cupscale.Forms;
//using System.IO.Compression;
using Cupscale.Properties;
using Ionic.Zip;

namespace Cupscale.IO
{
	internal class ShippedEsrgan
	{
		public static string path;

		public static async Task Init()
		{
			Console.WriteLine("ShippedEsrgan Init()");
			path = Paths.esrganPath;
			long targetSize = 301969327; ;
			long installationSize;
			try
            {
				installationSize = IOUtils.GetDirSize(path, new string[] { ".pyc", ".txt" });
			}
            catch
            {
				installationSize = 0;
			}
			Logger.Log("Installation Size: " + installationSize + "/" + targetSize + " bytes");
			if (installationSize != targetSize)
				await Extract();
		}

		public static async Task Extract()
		{
			Program.mainForm.Enabled = false;
			DialogForm dialogForm = new DialogForm("Installing resources...\nThis only needs to be done once.");

			File.WriteAllBytes(Path.Combine(IOUtils.GetAppDataDir(), "esrgan.zip"), Resources.ShippedEsrgan);
			File.WriteAllBytes(Path.Combine(IOUtils.GetAppDataDir(), "ncnn.zip"), Resources.ShippedNCNN);

			await UnSevenzip(Path.Combine(IOUtils.GetAppDataDir(), "esrgan.zip"));
			await UnSevenzip(Path.Combine(IOUtils.GetAppDataDir(), "ncnn.zip"));

			dialogForm.Close();
			Program.mainForm.Enabled = true;
		}

		static async Task UnSevenzip (string path)
        {
			SevenZipNET.SevenZipExtractor extractor = new SevenZipNET.SevenZipExtractor(path);
			extractor.ExtractAll(IOUtils.GetAppDataDir());
			File.Delete(path);
		}

		public static bool Exists()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo == null || !Directory.Exists(directoryInfo.FullName))
			{
				return false;
			}
			FileInfo[] files = directoryInfo.GetFiles("*.py", SearchOption.AllDirectories);
			if (files.Length >= 4)
			{
				return true;
			}
			return false;
		}
	}
}
