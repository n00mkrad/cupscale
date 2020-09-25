using System;
using System.IO;
using System.Windows.Forms;
using DT = System.DateTime;

namespace Cupscale
{
	internal class Logger
	{
		public static TextBox textbox;

		public static string sessionLog;

		public static string logFile;

		public static void Log(string s, bool logToFile = true, bool noLineBreak = false, bool replaceLastLine = false)
		{
			Console.WriteLine(s);

			if (replaceLastLine)
			{
				textbox.Text = textbox.Text.Remove(textbox.Text.LastIndexOf(Environment.NewLine));
				sessionLog = sessionLog.Remove(sessionLog.LastIndexOf(Environment.NewLine));
			}

			if(!noLineBreak)
				sessionLog += Environment.NewLine + s;
			else
				sessionLog += " " + s;

			if (logToFile)
				LogToFile(s, noLineBreak);
		}

		public static void LogToFile(string s, bool noLineBreak)
        {
			if (string.IsNullOrWhiteSpace(logFile))
				logFile = Path.Combine(IOUtils.GetAppDataDir(), "log.txt");
			string time = DT.Now.Month + "-" + DT.Now.Day + "-" + DT.Now.Year + " " + DT.Now.Hour + ":" + DT.Now.Minute + ":" + DT.Now.Second;

            try
            {
				if (!noLineBreak)
					File.AppendAllText(logFile, Environment.NewLine + time + ": " + s);
				else
					File.AppendAllText(logFile, " " + s);
			}
            catch
            {
				// idk how to deal with this race condition (?)
            }
		}

		public static string GetSessionLog ()
        {
			return sessionLog;
        }
	}
}
