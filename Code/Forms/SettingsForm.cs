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
            // General
            Config.LoadGuiElement(modelPath);
            Config.LoadGuiElement(alphaBgColor);
            Config.LoadGuiElement(jpegExtension);
            Config.LoadComboxIndex(previewFormat);
            Config.LoadGuiElement(reloadImageBeforeUpscale);
            Config.LoadComboxIndex(comparisonUseScaling);
            Config.LoadGuiElement(modelSelectAutoExpand);

            // ESRGAN Pytorch
            Config.LoadComboxIndex(esrganPytorchPythonRuntime);
            Config.LoadComboxIndex(esrganPytorchAlphaMode);
            Config.LoadComboxIndex(esrganPytorchAlphaDepth);
            Config.LoadComboxIndex(esrganPytorchSeamlessMode);
            Config.LoadGuiElement(esrganPytorchGpuId);
            Config.LoadGuiElement(esrganPytorchMultiGpu);
            Config.LoadGuiElement(esrganPytorchCpu);
            Config.LoadGuiElement(esrganPytorchFp16);

            // ESRGAN NCNN
            Config.LoadGuiElement(esrganNcnnTilesize);
            Config.LoadGuiElement(esrganNcnnTta);
            Config.LoadGuiElement(esrganNcnnGpu);

            // RealESRGAN NCNN
            Config.LoadGuiElement(realEsrganNcnnTilesize);
            Config.LoadGuiElement(realEsrganNcnnTta);
            Config.LoadGuiElement(realEsrganNcnnGpus);

            // Formats
            Config.LoadGuiElement(jpegQ);
            Config.LoadGuiElement(webpQ);
            Config.LoadGuiElement(dxtMode);
            Config.LoadGuiElement(ddsEnableMips);
            Config.LoadGuiElement(flipTga);
            Config.LoadGuiElement(useMozJpeg);

            // Video
            Config.LoadGuiElement(crf);
            Config.LoadGuiElement(h265);
            Config.LoadGuiElement(gifskiQ);
            Config.LoadGuiElement(vidEnableAudio);

            // Debug
            Config.LoadGuiElement(logIo);
            Config.LoadGuiElement(logStatus);
            Config.LoadComboxIndex(cmdDebugMode);
        }

        private async void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await Task.Delay(100);
            SaveSettings();
            await EmbeddedPython.Init();
            Program.mainForm.LoadEsrganOptions();

            if(Config.GetInt("esrganPytorchPythonRuntime") == 1 && !File.Exists(EmbeddedPython.GetEmbedPyPath()))
            {
                MsgBox msg = Program.ShowMessage("You enabled the embedded Python runtime but haven't downloaded and installed it.\n" +
                    "You can download it in the Dependency Checker window.");
                while (DialogQueue.IsOpen(msg)) await Task.Delay(50);
                
                new DependencyCheckerForm(true).ShowDialog();
            }
        }

        void SaveSettings()
        {
            Clamp();

            // General
            Config.SaveGuiElement(modelPath);
            Config.SaveGuiElement(alphaBgColor);
            Config.SaveGuiElement(jpegExtension);
            Config.SaveComboxIndex(previewFormat);
            Config.SaveGuiElement(reloadImageBeforeUpscale);
            Config.SaveComboxIndex(comparisonUseScaling);
            Config.SaveGuiElement(modelSelectAutoExpand);

            // ESRGAN Pytorch
            Config.SaveComboxIndex(esrganPytorchPythonRuntime);
            Config.SaveComboxIndex(esrganPytorchAlphaMode);
            Config.SaveComboxIndex(esrganPytorchAlphaDepth);
            Config.SaveComboxIndex(esrganPytorchSeamlessMode);
            Config.SaveGuiElement(esrganPytorchGpuId);
            Config.SaveGuiElement(esrganPytorchMultiGpu);
            Config.SaveGuiElement(esrganPytorchCpu);
            Config.SaveGuiElement(esrganPytorchFp16);

            // ESRGAN NCNN
            Config.SaveGuiElement(esrganNcnnTilesize);
            Config.SaveGuiElement(esrganNcnnTta);
            Config.SaveGuiElement(esrganNcnnGpu);

            // RealESRGAN NCNN
            Config.SaveGuiElement(realEsrganNcnnTilesize);
            Config.SaveGuiElement(realEsrganNcnnTta);
            Config.SaveGuiElement(realEsrganNcnnGpus);

            // Formats
            Config.SaveGuiElement(jpegQ, true);
            Config.SaveGuiElement(webpQ, true);
            Config.SaveGuiElement(dxtMode);
            Config.SaveGuiElement(ddsEnableMips);
            Config.SaveGuiElement(flipTga);
            Config.SaveGuiElement(useMozJpeg);
            // Video

            Config.SaveGuiElement(crf);
            Config.SaveGuiElement(h265);
            Config.SaveGuiElement(gifskiQ);
            Config.SaveGuiElement(vidEnableAudio);

            // Debug
            Config.SaveGuiElement(logIo);
            Config.SaveGuiElement(logStatus);
            Config.SaveComboxIndex(cmdDebugMode);
        }

        void Clamp ()
        {
            jpegQ.Text = jpegQ.GetInt().Clamp(0, 100).ToString();
            webpQ.Text = webpQ.GetInt().Clamp(0, 100).ToString();
            crf.Text = crf.GetInt().Clamp(0, 51).ToString();
            gifskiQ.Text = gifskiQ.GetInt().Clamp(0, 100).ToString();
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
            await Installer.Install();
            BringToFront();
        }

        private async void reinstallCleanBtn_Click(object sender, EventArgs e)
        {
            Installer.Uninstall(false);
            await Installer.Install();
            BringToFront();
        }

        private void uninstallResBtn_Click(object sender, EventArgs e)
        {
            Installer.Uninstall(false);
            Program.ShowMessage("Uninstalled resources.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.\n" +
                "However, your settings file was not deleted.", "Message");
            Logger.disable = true;
            Config.disable = true;
            Program.Quit();
        }

        private void uninstallFullBtn_Click(object sender, EventArgs e)
        {
            Close();
            Installer.Uninstall(true);
            Program.ShowMessage("Uninstalled all files.\nYou can now delete Cupscale.exe if you want to completely remove it from your PC.", "Message");
            Logger.disable = true;
            Config.disable = true;
            Program.Quit();
        }

        private void installPyBtn_Click(object sender, EventArgs e)
        {
            new DependencyCheckerForm().ShowDialog();
            uninstallPyBtn_VisibleChanged(null, null);
        }

        private async void uninstallPyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Uninstalling Python Runtime...");
                await Task.Delay(50);
                Directory.Delete(EmbeddedPython.GetEmbedPyPath().GetParentDir(), true);
                dialogForm.Close();
                uninstallPyBtn.Enabled = false;

                Config.Set("esrganPytorchPythonRuntime", "0");
                Config.LoadComboxIndex(esrganPytorchPythonRuntime);
            }
            catch (Exception ex)
            {
                Program.CloseTempForms();
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