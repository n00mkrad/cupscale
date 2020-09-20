using System.Windows.Forms;

namespace Cupscale.UI
{
	internal class ConfigTabHelper
	{
		public static void LoadSettings(ComboBox tilesize, CheckBox alpha, TextBox modelPath, TextBox alphaColor, TextBox jpegExt, CheckBox useCpu)
		{
			tilesize.Text = Config.Get("tilesize");
			alpha.Checked = bool.Parse(Config.Get("alpha"));
			modelPath.Text = Config.Get("modelPath");
			alphaColor.Text = Config.Get("alphaBgColor");
			jpegExt.Text = Config.Get("jpegExtension");
			useCpu.Checked = bool.Parse(Config.Get("useCpu"));
		}

		public static void SaveSettings(ComboBox tilesize, CheckBox alpha, TextBox modelPath, TextBox alphaColor, TextBox jpegExt, CheckBox useCpu)
		{
			Config.Set("tilesize", tilesize.Text.TrimNumbers());
			Config.Set("alpha", alpha.Checked.ToString());
			Config.Set("modelPath", modelPath.Text.Trim());
			Config.Set("alphaBgColor", alphaColor.Text.Trim());
			Config.Set("jpegExtension", jpegExt.Text.Trim());
			Config.Set("useCpu", useCpu.Checked.ToString());
			//MessageBox.Show("Saved settings to config file.", "Notice");
			EsrganData.CheckModelDir();
		}
	}
}
