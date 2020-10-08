using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.Forms
{
    public partial class SettingsForm : Form
    {

        bool initialized = false;

        public SettingsForm()
        {
            InitializeComponent();
            Show();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Program.mainForm.Enabled = false;
            Logger.textbox = logTbox;
            LoadSettings();
            initialized = true;
        }

        void LoadSettings()
        {
            // ESRGAN/Cupscale
            Config.LoadComboxIndex(esrganVersion);
            Config.LoadGuiElement(tilesize);
            Config.LoadGuiElement(alpha);
            Config.LoadGuiElement(seamless);
            Config.LoadGuiElement(modelPath);
            Config.LoadGuiElement(alphaBgColor);
            Config.LoadGuiElement(jpegExtension);
            Config.LoadGuiElement(useCpu);
            Config.LoadGuiElement(useNcnn);
            Config.LoadComboxIndex(previewFormat);
            // Formats
            Config.LoadGuiElement(jpegQ);
            Config.LoadGuiElement(webpQ);
            Config.LoadGuiElement(dxtMode);
            Config.LoadGuiElement(ddsEnableMips);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Program.mainForm.Enabled = true;
        }

        void SaveSettings()
        {
            // ESRGAN/Cupscale
            Config.SaveComboxIndex(esrganVersion);
            Config.SaveGuiElement(tilesize, true);
            Config.SaveGuiElement(alpha);
            Config.SaveGuiElement(seamless);
            Config.SaveGuiElement(modelPath);
            Config.SaveGuiElement(alphaBgColor);
            Config.SaveGuiElement(jpegExtension);
            Config.SaveGuiElement(useCpu);
            Config.SaveGuiElement(useNcnn);
            Config.SaveComboxIndex(previewFormat);

            // Formats
            Config.SaveGuiElement(jpegQ, true);
            Config.SaveGuiElement(webpQ, true);
            Config.SaveGuiElement(dxtMode);
            Config.SaveGuiElement(ddsEnableMips);
        }

        private void confAlphaBgColorBtn_Click(object sender, EventArgs e)
        {
            alphaBgColorDialog.ShowDialog();
            string colorStr = ColorTranslator.ToHtml(Color.FromArgb(alphaBgColorDialog.Color.ToArgb())).Replace("#", "") + "FF";
            alphaBgColor.Text = colorStr;
            Config.Set("alphaBgColor", colorStr);
        }

        private void logTbox_VisibleChanged(object sender, EventArgs e)
        {
            if (logTbox.Visible)
                logTbox.Text = Logger.GetSessionLog();
        }

        private void useNcnn_CheckedChanged(object sender, EventArgs e)
        {
            if (useNcnn.Checked && initialized)
                MessageBox.Show("This only serves as a fallback mode.\nDon't use this if you have an Nvidia GPU.\n\n" +
                    "The following features do not work with Vulkan/NCNN:\n- Model Interpolation\n- Model Chaining\n"
                    + "- Custom Tile Size (Uses Automatic Tile Size)\n\nAlpha is supported and always enabled with NCNN.", "Warning");
        }


        private void selectModelsPathBtn_Click(object sender, EventArgs e)
        {
            modelsPathDialog.ShowDialog();
            modelPath.Text = modelsPathDialog.SelectedPath;
        }

        private async void reinstallOverwriteBtn_Click(object sender, EventArgs e)
        {
            await ShippedEsrgan.Install();
            BringToFront();
        }

        private async void reinstallCleanBtn_Click(object sender, EventArgs e)
        {
            ShippedEsrgan.Uninstall(false);
            await ShippedEsrgan.Install();
            BringToFront();
        }

        private void uninstallResBtn_Click(object sender, EventArgs e)
        {
            ShippedEsrgan.Uninstall(false);
            MessageBox.Show("Uninstalled resources.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.\n" +
                "However, your settings file was not deleted.", "Message");
            Program.Quit();
        }

        private void uninstallFullBtn_Click(object sender, EventArgs e)
        {
            Close();
            ShippedEsrgan.Uninstall(true);
            MessageBox.Show("Uninstalled all files.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.", "Message");
            Program.Quit();
        }

        private void esrganVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            seamless.Enabled = esrganVersion.SelectedIndex == 1;
            seamlessJoeyWarn.Visible = esrganVersion.SelectedIndex == 0;
        }
    }
}