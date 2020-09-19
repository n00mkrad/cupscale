using System.IO;
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
	}
}
