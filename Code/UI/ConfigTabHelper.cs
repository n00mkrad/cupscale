using System.Windows.Forms;

namespace Cupscale.UI
{
	internal class ConfigTabHelper
	{
		public static void LoadEsrganSettings(ComboBox tilesize, CheckBox alpha, TextBox modelPath, TextBox alphaColor, TextBox jpegExt)
		{
			tilesize.Text = Config.Get("tilesize");
			alpha.Checked = bool.Parse(Config.Get("alpha"));
			modelPath.Text = Config.Get("modelPath");
			alphaColor.Text = Config.Get("alphaBgColor");
			jpegExt.Text = Config.Get("jpegExtension");
		}

		public static void SaveSettings(ComboBox tilesize, CheckBox alpha, TextBox modelPath, TextBox alphaColor, TextBox jpegExt)
		{
			Config.Set("tilesize", tilesize.Text.TrimNumbers());
			Config.Set("alpha", alpha.Checked.ToString());
			Config.Set("modelPath", modelPath.Text.Trim());
			Config.Set("alphaBgColor", alphaColor.Text.Trim());
			Config.Set("jpegExtension", jpegExt.Text.Trim());
			//MessageBox.Show("Saved settings to config file.", "Notice");
			EsrganData.CheckModelDir();
		}
	}
}
