using Cupscale.IO;
using Cupscale.OS;
using Cupscale.UI;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            //Show();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //if(Program.mainForm != null)
                //Program.mainForm.Enabled = false;
            Logger.textbox = logTbox;
            LoadSettings();
            initialized = true;
        }

        void LoadSettings()
        {
            // ESRGAN/Cupscale
            Config.LoadComboxIndex(esrganVer);
            Config.LoadGuiElement(tilesize);
            Config.LoadGuiElement(alpha);
            Config.LoadComboxIndex(seamlessMode);
            Config.LoadGuiElement(modelPath);
            Config.LoadGuiElement(alphaBgColor);
            Config.LoadGuiElement(jpegExtension);
            Config.LoadComboxIndex(cudaFallback);
            Config.LoadComboxIndex(previewFormat);
            Config.LoadGuiElement(reloadImageBeforeUpscale);
            Config.LoadComboxIndex(pythonRuntime);
            // Formats
            Config.LoadGuiElement(jpegQ);
            Config.LoadGuiElement(webpQ);
            Config.LoadGuiElement(dxtMode);
            Config.LoadGuiElement(ddsEnableMips);
            Config.LoadGuiElement(flipTga);
            Config.LoadGuiElement(useMozJpeg);
            // Debug
            Config.LoadGuiElement(logIo);
            Config.LoadGuiElement(logStatus);
            Config.LoadComboxIndex(cmdDebugMode);
        }

        private async void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await Task.Delay(100);
            SaveSettings();
            EmbeddedPython.Init();
            if(Config.GetInt("pythonRuntime") == 1 && !File.Exists(EmbeddedPython.GetEmbedPyPath()))
            {
                Program.ShowMessage("You enabled the embedded Python runtime but haven't downloaded and installed it.\n" +
                    "You can download it in the Dependency Checker window.");
                new DependencyCheckerForm(true).ShowDialog();
            }
        }

        void SaveSettings()
        {
            // ESRGAN/Cupscale
            Config.SaveComboxIndex(esrganVer);
            Config.SaveGuiElement(tilesize, true);
            Config.SaveGuiElement(alpha);
            Config.SaveComboxIndex(seamlessMode);
            Config.SaveGuiElement(modelPath);
            Config.SaveGuiElement(alphaBgColor);
            Config.SaveGuiElement(jpegExtension);
            Config.SaveComboxIndex(cudaFallback);
            Config.SaveComboxIndex(previewFormat);
            Config.SaveGuiElement(reloadImageBeforeUpscale);
            Config.SaveComboxIndex(pythonRuntime);
            // Formats
            Config.SaveGuiElement(jpegQ, true);
            Config.SaveGuiElement(webpQ, true);
            Config.SaveGuiElement(dxtMode);
            Config.SaveGuiElement(ddsEnableMips);
            Config.SaveGuiElement(flipTga);
            Config.SaveGuiElement(useMozJpeg);
            // Debug
            Config.SaveGuiElement(logIo);
            Config.SaveGuiElement(logStatus);
            Config.SaveComboxIndex(cmdDebugMode);
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
            logTbox.SelectionStart = logTbox.Text.Length;
            logTbox.ScrollToCaret();
        }

        private void selectModelsPathBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            if (Directory.Exists(modelPath.Text.Trim()))
                folderDialog.InitialDirectory = modelPath.Text;
            folderDialog.IsFolderPicker = true;
            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                modelPath.Text = folderDialog.FileName;
        }

        private async void reinstallOverwriteBtn_Click(object sender, EventArgs e)
        {
            await ShippedFiles.Install();
            BringToFront();
        }

        private async void reinstallCleanBtn_Click(object sender, EventArgs e)
        {
            ShippedFiles.Uninstall(false);
            await ShippedFiles.Install();
            BringToFront();
        }

        private void uninstallResBtn_Click(object sender, EventArgs e)
        {
            ShippedFiles.Uninstall(false);
            Program.ShowMessage("Uninstalled resources.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.\n" +
                "However, your settings file was not deleted.", "Message");
            Logger.disable = true;
            Config.disable = true;
            Program.Quit();
        }

        private void uninstallFullBtn_Click(object sender, EventArgs e)
        {
            Close();
            ShippedFiles.Uninstall(true);
            Program.ShowMessage("Uninstalled all files.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.", "Message");
            Logger.disable = true;
            Config.disable = true;
            Program.Quit();
        }

        private void esrganVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            seamlessMode.Enabled = esrganVer.SelectedIndex == 0;
        }

        private void cudaFallback_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Program.ShowMessage("This only serves as a fallback mode.\nDon't use this if you have an Nvidia GPU.\n\n" +
            //"The following features do not work with Vulkan/NCNN:\n- Model Interpolation\n- Model Chaining\n"
            //+ "- Custom Tile Size (Uses Automatic Tile Size)", "Warning");
        }

        private void installPyBtn_Click(object sender, EventArgs e)
        {
            new DependencyCheckerForm().ShowDialog();
            uninstallPyBtn_VisibleChanged(null, null);
        }

        private void uninstallPyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(EmbeddedPython.GetEmbedPyPath().GetParentDir(), true);
                uninstallPyBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.ErrorMessage("Can't uninstall embedded Python runtime: ", ex);
            }
        }

        private void uninstallPyBtn_VisibleChanged(object sender, EventArgs e)
        {
            if (uninstallPyBtn.Visible)
                uninstallPyBtn.Enabled = File.Exists(EmbeddedPython.GetEmbedPyPath());
        }
    }
}