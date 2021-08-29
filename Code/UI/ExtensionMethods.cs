using Cupscale.ImageUtils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
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
			if (str.Length < 1 || str == null)
				return 0;

			try
			{
				return int.Parse(str.TrimNumbers());
			}
			catch (Exception e)
			{
				Logger.Log("Failed to parse \"" + str + "\" to int: " + e.Message);
				return 0;
			}
		}

		public static int GetInt(this TextBox textbox)
		{
			return textbox.Text.GetInt();
		}

		public static int GetInt(this ComboBox combobox)
		{
			return combobox.Text.GetInt();
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

		public static string Wrap (this string path, bool addSpaceFront = false, bool addSpaceEnd = false)
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

		public static long RoundToLong(this float f)
		{
			return (long)Math.Round(f);
		}

		public static int Clamp (this int i, int min, int max)
        {
			if (i < min)
				i = min;
			if (i > max)
				i = max;
			return i;
		}

		public static string TrimWhitespaces(this string str)
		{
			if (str == null) return str;
			var newString = new StringBuilder();
			bool previousIsWhitespace = false;
			for (int i = 0; i < str.Length; i++)
			{
				if (Char.IsWhiteSpace(str[i]))
				{
					if (previousIsWhitespace)
						continue;
					previousIsWhitespace = true;
				}
				else
				{
					previousIsWhitespace = false;
				}
				newString.Append(str[i]);
			}
			return newString.ToString();
		}

        public static string[] SplitIntoLines(this string str)
        {
            return Regex.Split(str, "\r\n|\r|\n");
        }

		public static string Trunc(this string inStr, int maxChars, bool addEllipsis = true)
		{
			string str = inStr.Length <= maxChars ? inStr : inStr.Substring(0, maxChars);
			if (addEllipsis && inStr.Length > maxChars)
				str += "…";
			return str;
		}
	}
}
