using System;
using System.Windows.Forms;

namespace Cupscale
{
	internal class Logger
	{
		public static TextBox textbox;

		public static void Log(string s, bool replaceLastLine = false)
		{
			Console.WriteLine(s);
			if (replaceLastLine)
			{
				textbox.Text = textbox.Text.Remove(textbox.Text.LastIndexOf(Environment.NewLine));
			}
			s = s.Replace("\n", Environment.NewLine);
			if (textbox != null)
			{
				Console.WriteLine("appending to logTbox: " + s);
				textbox.AppendText(Environment.NewLine + s);
			}
            else
            {
				Console.WriteLine("logTbox is null!");
            }
		}
	}
}
