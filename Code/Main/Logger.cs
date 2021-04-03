using Cupscale.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using Cupscale.IO;
using DT = System.DateTime;

namespace Cupscale
{
	internal class Logger
	{
		public static TextBox textbox;

		public static string sessionLog;

		public static string file;

		public static bool disable;

		public static bool doLogIo;
		public static bool doLogStatus;

		public static void Init ()
        {
			file = Path.Combine(Paths.GetDataPath(), "sessionlog.txt");
			doLogIo = Config.GetBool("logIo");
			doLogStatus = Config.GetBool("logStatus");
			PrintArgs();
		}

		public static void PrintArgs ()
        {
			foreach (string arg in Environment.GetCommandLineArgs())
				Log("Arg: " + arg);
		}

		public static void Log(string s, bool logToFile = true, bool noLineBreak = false, bool replaceLastLine = false)
		{
			if (disable) return;

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
			if (string.IsNullOrWhiteSpace(file))
				file = Path.Combine(Paths.GetDataPath(), "sessionlog.txt");
			string time = DT.Now.Month + "-" + DT.Now.Day + "-" + DT.Now.Year + " " + DT.Now.Hour + ":" + DT.Now.Minute + ":" + DT.Now.Second;

            try
            {
				if (!noLineBreak)
					File.AppendAllText(file, Environment.NewLine + time + ": " + s);
				else
					File.AppendAllText(file, " " + s);
			}
            catch
            {
				// idk how to deal with this race condition (?) but just ignoring it seems to work lol
            }
		}

		public static string GetSessionLog ()
        {
			return sessionLog;
        }

		public static MsgBox ErrorMessage (string msg, Exception e)
        {
			string text = $"{msg}\n\n{e.Message}\n\nStack Trace:\n{e.StackTrace}";
			Clipboard.SetText(text);
			Log(text);
			return Program.ShowMessage(text + "\n\nThe error message was copied to the clipboard.", "Error");
		}
	}
}
