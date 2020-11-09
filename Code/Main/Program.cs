using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Cupscale.UI;
using ImageMagick;
using Paths = Cupscale.IO.Paths;

namespace Cupscale
{
	internal static class Program
	{
		public static MainForm mainForm;
		public static string lastOutputDir;
		public static string lastImgPath;		// Single Image
		public static string lastDirPath;		// Batch
		public static string lastVidPath;       // Video
		public static string lastModelName;
		public static string currentModel1;
		public static string currentModel2;
		public static FilterType currentFilter = FilterType.Point;

		public static List<Form> currentTemporaryForms = new List<Form>();	// Temp forms that get closed when something gets cancelled
		public static List<MsgBox> openMessageBoxes = new List<MsgBox>();  // Temp forms that get closed when something gets cancelled

		public static bool busy;

		[STAThread]
		private static void Main()
		{
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.EnableVisualStyles();
			IOUtils.DeleteIfExists(Path.Combine(IOUtils.GetAppDataDir(), "sessionlog.txt"));
			Config.Init();
			Logger.Init();
			Paths.Init();
			ResourceLimits.Memory = (ulong)Math.Round(ResourceLimits.Memory * 1.5f);
			Cleanup();
			Application.Run(new MainForm());
		}

		public static MsgBox ShowMessage (string msg, string title = "Message")
        {
			//MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
			DialogQueue.Init();
			MsgBox msgBox = new MsgBox(msg.Replace("\n", Environment.NewLine), title);
			DialogQueue.ShowDialog(msgBox);
			return msgBox;
		}

		public static void Cleanup ()
        {
            try
            {
				IOUtils.ClearDir(Paths.previewPath);
				IOUtils.ClearDir(Paths.previewOutPath);
				IOUtils.ClearDir(Paths.clipboardFolderPath);
				IOUtils.ClearDir(Paths.imgInPath);
				IOUtils.ClearDir(Paths.imgOutPath);
				IOUtils.ClearDir(Paths.imgOutNcnnPath);
				IOUtils.ClearDir(Paths.tempImgPath.GetParentDir());
				IOUtils.ClearDir(Path.Combine(IOUtils.GetAppDataDir(), "giftemp"));
				IOUtils.DeleteIfExists(Path.Combine(Paths.presetsPath, "lastUsed"));
				IOUtils.ClearDir(Paths.compositionOut);
				IOUtils.ClearDir(Paths.framesOutPath);
				IOUtils.DeleteIfExists(Path.Combine(IOUtils.GetAppDataDir(), "frames-out.mp4"));
			}
			catch (Exception e)
            {
				Logger.Log("Error during cleanup: " + e.Message);
            }
		}

		public static void CloseTempForms ()
        {
			foreach (Form form in currentTemporaryForms.ToList())
				form.Close();
        }

		public static async Task PutTaskDelay()
		{
			await Task.Delay(1);
		}

		public static int GetPercentage (float val1, float val2)
        {
			return (int)Math.Round((val1 / val2) * 100f);
        }

		public static void Quit ()
        {
			Application.Exit();
		}
	}
}
