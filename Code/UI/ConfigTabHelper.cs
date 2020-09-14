using System.Windows.Forms;

namespace Cupscale.UI
{
	internal class ConfigTabHelper
	{
		public static void LoadEsrganSettings(ComboBox tilesizeBox, CheckBox alphaBox, TextBox modelPathBox, TextBox alphaTextbox)
		{
			tilesizeBox.Text = Config.Get("tilesize");
			alphaBox.Checked = bool.Parse(Config.Get("alpha"));
			modelPathBox.Text = Config.Get("modelPath");
			alphaTextbox.Text = Config.Get("alphaBgColor");
		}

		public static void SaveSettings(ComboBox tilesizeBox, CheckBox alphaBox, TextBox modelPathBox, TextBox alphaTextbox)
		{
			Config.Set("tilesize", tilesizeBox.Text.TrimNumbers());
			Config.Set("alpha", alphaBox.Checked.ToString());
			Config.Set("modelPath", modelPathBox.Text.Trim());
			Config.Set("alphaBgColor", alphaTextbox.Text.Trim());
			//MessageBox.Show("Saved settings to config file.", "Notice");
			EsrganData.CheckModelDir();
		}
	}
}
