using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cupscale.UI
{
	public static class ExtensionMethods
	{
		public static string TrimNumbers(this string s)
		{
			s = Regex.Replace(s, "[^.0-9]", "");
			return s.Trim();
		}

		public static int GetInt(this TextBox textbox)
		{
			return int.Parse(textbox.Text.TrimNumbers());
		}

		public static int GetInt(this ComboBox combobox)
		{
			return int.Parse(combobox.Text.TrimNumbers());
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
	}
}
