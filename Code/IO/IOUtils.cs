using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cupscale
{
	internal class IOUtils
	{
		public static string GetAppDataDir()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string text = Path.Combine(folderPath, "Cupscale");
			Directory.CreateDirectory(text);
			return text;
		}

		public static string GetExeDir()
		{
			return AppDomain.CurrentDomain.BaseDirectory;
		}

		public static Image GetImage(string path)
		{
			using MemoryStream stream = new MemoryStream(File.ReadAllBytes(path));
			return Image.FromStream(stream);
		}

		public static string[] ReadLines(string path)
		{
			List<string> lines = new List<string>();
			using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
			using (var sr = new StreamReader(fs, Encoding.UTF8))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					lines.Add(line);
				}
			}
			return lines.ToArray();
		}

		public static bool IsPathDirectory(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			path = path.Trim();
			if (Directory.Exists(path))
			{
				return true;
			}
			if (File.Exists(path))
			{
				return false;
			}
			if (new string[2]
			{
				"\\",
				"/"
			}.Any((string x) => path.EndsWith(x)))
			{
				return true;
			}
			return string.IsNullOrWhiteSpace(Path.GetExtension(path));
		}

		public static bool IsFileValid(string path)
		{
			if (path == null)
			{
				return false;
			}
			if (!File.Exists(path))
			{
				return false;
			}
			return true;
		}

		public static void Copy(string sourceDir, string targetDir, bool move = false)
		{
			Logger.Log("Copying directory \"" + sourceDir + "\" to \"" + targetDir + "\" (Move: " + move + ")");
			Directory.CreateDirectory(targetDir);
			DirectoryInfo source = new DirectoryInfo(sourceDir);
			DirectoryInfo target = new DirectoryInfo(targetDir);
			CopyWork(source, target, move);
		}

		private static void CopyWork(DirectoryInfo source, DirectoryInfo target, bool move)
		{
			DirectoryInfo[] directories = source.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				CopyWork(directoryInfo, target.CreateSubdirectory(directoryInfo.Name), move);
			}
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				if (move)
				{
					fileInfo.MoveTo(Path.Combine(target.FullName, fileInfo.Name));
				}
				else
				{
					fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), overwrite: true);
				}
			}
		}

		public static void DeleteContentsOfDir(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.Delete();
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				directoryInfo2.Delete(recursive: true);
			}
		}

		public static void ReplaceInFilenamesDir(string dir, string textToFind, string textToReplace, bool recursive = true, string wildcard = "*")
		{
			int counter = 1;
			DirectoryInfo d = new DirectoryInfo(dir);
			FileInfo[] files = null;
			if (recursive)
				files = d.GetFiles(wildcard, SearchOption.AllDirectories);
			else
				files = d.GetFiles(wildcard, SearchOption.TopDirectoryOnly);
			foreach (FileInfo file in files)
			{
				ReplaceInFilename(file.FullName, textToFind, textToReplace);
				counter++;
			}
		}

		public static void ReplaceInFilename(string path, string textToFind, string textToReplace)
		{
			string ext = Path.GetExtension(path);
			string newFilename = Path.GetFileNameWithoutExtension(path).Replace(textToFind, textToReplace);
			string targetPath = Path.Combine(Path.GetDirectoryName(path), newFilename + ext);
			if (File.Exists(targetPath))
			{
				//Program.Print("Skipped " + path + " because a file with the target name already exists.");
				return;
			}
			File.Move(path, targetPath);
		}

		public static bool TryCopy (string source, string dest, bool overwrite)		// Copy with error handling. Returns false if failed
        {
            try
            {
				File.Copy(source, dest, overwrite);
			}
			catch (Exception e)
            {
				MessageBox.Show("Copy from \"" + source + "\" to \"" + dest + " (Overwrite: " + overwrite + " failed: \n\n" + e.Message);
				return false;
            }
			return true;
        }
	}
}
