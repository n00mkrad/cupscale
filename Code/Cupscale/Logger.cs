using System;
using System.Windows.Forms;

namespace Cupscale
{
	internal class Logger
	{
		public static TextBox textbox;

		public static string sessionLog;

		public static void Log(string s, bool replaceLastLine = false)
		{
			Console.WriteLine(s);
			if (replaceLastLine)
			{
				textbox.Text = textbox.Text.Remove(textbox.Text.LastIndexOf(Environment.NewLine));
			}

			sessionLog = sessionLog + s + Environment.NewLine;

			s = s.Replace("\n", Environment.NewLine);
			/*
			if (textbox != null)
			{
				textbox.AppendText(Environment.NewLine + s);
			}
            else
            {
				Console.WriteLine("logTbox is null!");
            }
			*/
		}

		public static string GetSessionLog ()
        {
			return sessionLog;
        }
	}
}
