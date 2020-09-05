using System;
using System.IO;
//using System.IO.Compression;
using Cupscale.Properties;
using Ionic.Zip;

namespace Cupscale.IO
{
	internal class ShippedEsrgan
	{
		public static string path;

		public static void Init()
		{
			Console.WriteLine("ShippedEsrgan Init()");
			path = Paths.esrganPath;
			Extract();
			/*
			if (!Exists())
			{
				Console.WriteLine("ESRGAN path doesn't exist, extracting");
				Extract();
			}
			*/
		}

		public static void Extract()
		{
			string sourceArchiveFileName = Path.Combine(IOUtils.GetAppDataDir(), "esrgan.zip");
			string destinationDirectoryName = Path.Combine(IOUtils.GetAppDataDir());
			File.WriteAllBytes(sourceArchiveFileName, Resources.ShippedEsrgan);
			//ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
			using (ZipFile zip = ZipFile.Read(sourceArchiveFileName))
			{
				foreach (ZipEntry e in zip)
					e.Extract(destinationDirectoryName, ExtractExistingFileAction.OverwriteSilently);
			}
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
