using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cupscale
{
	internal class EsrganData
	{
		public static List<string> models = new List<string>();
		public static List<string> modelsFullPath = new List<string>();

		public static void CheckModelDir()
		{
			if (Config.Get("modelPath") == null)
			{
				MessageBox.Show("Please set a model path in the Settings tab.", "Notice");
			}
			else if (!Directory.Exists(Config.Get("modelPath")))
			{
				MessageBox.Show("The model path you entered isn't valid!", "Notice");
			}
		}

		public static void ReloadModelList()
		{
			string text = Config.Get("modelPath");
			Logger.Log("Loading model names from " + text);
            if (!Directory.Exists(text))
            {
				Logger.Log("Model dir doesn't exist!");
				return;
			}
			models.Clear();
			modelsFullPath.Clear();
			string[] files = Directory.GetFiles(text);
			string[] array = files;
			foreach (string path in array)
			{
				string fileName = Path.GetFileName(path);
				if (fileName.EndsWith(".pth"))
				{
					models.Add(fileName.Replace(".pth", ""));
					modelsFullPath.Add(path);
				}
			}
		}
	}
}
