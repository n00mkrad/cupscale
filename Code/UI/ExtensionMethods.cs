using Cupscale.ImageUtils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cupscale.UI
{
	public static class ExtensionMethods
	{
		public static string TrimNumbers(this string s, bool allowDotComma = false)
		{
			if (!allowDotComma)
				s = Regex.Replace(s, "[^0-9]", "");
			else
				s = Regex.Replace(s, "[^.,0-9]", "");
			return s.Trim();
		}

		public static int GetInt(this string str)
		{
			return int.Parse(TrimNumbers(str));
		}

		public static int GetInt(this TextBox textbox)
		{
            try { return int.Parse(textbox.Text.TrimNumbers()); }
            catch { return 0; }
		}

		public static int GetInt(this ComboBox combobox)
		{
			try { return int.Parse(combobox.Text.TrimNumbers()); }
			catch { return 0; }
		}

		public static string GetParentDir (this string path)
        {
			return Directory.GetParent(path).FullName;
		}

		public static string TitleCase (this string str)
        {
			return Regex.Replace(str, @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
		}

		public static string RemoveSpaces(this string input)
		{
			return new string(input.Where(c => !Char.IsWhiteSpace(c)).ToArray());
		}

		public static string ToStringTitleCase(this Enum en)
		{
			return en.ToString().TitleCase();
		}

		public static string WrapPath (this string path, bool addSpaceFront = false, bool addSpaceEnd = false)
		{
			string s = "\"" + path + "\"";
			if (addSpaceFront)
				s =  " " + s;
			if (addSpaceEnd)
				s = s + " ";
			return s;
		}

		public static string ReplaceInFilename (this string path, string textToFind, string textToReplace, bool includeExtension = true)
        {
			string ext = Path.GetExtension(path);
			string newFilename = Path.GetFileNameWithoutExtension(path).Replace(textToFind, textToReplace);
			if (includeExtension)
				newFilename = Path.GetFileName(path).Replace(textToFind, textToReplace);
			string targetPath = Path.Combine(Path.GetDirectoryName(path), newFilename);
			if (!includeExtension)
				targetPath += ext;
			return targetPath;
		}

		public static Image Scale (this Image img, float scale, InterpolationMode filtering)
        {
			return ImageOperations.Scale(img, scale, filtering);
        }

		public static string ReplaceInFilename(string path, string find, string replaceWith)
		{
			string parentDir = path.GetParentDir();
			string filename = Path.GetFileName(path);
			return Path.Combine(parentDir, filename.Replace(find, replaceWith));
		}

		public static int RoundToInt (this float f)
        {
			return (int)Math.Round(f);
        }

		public static int Clamp (this int i, int min, int max)
        {
			if (i < min)
				i = min;
			if (i > max)
				i = max;
			return i;
		}
	}
}
