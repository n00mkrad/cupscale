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
            ConfigParser.LoadGuiElement(modelPath);
            ConfigParser.LoadGuiElement(alphaBgColor);
            ConfigParser.LoadGuiElement(jpegExtension);
            ConfigParser.LoadComboxIndex(previewFormat);
            ConfigParser.LoadGuiElement(reloadImageBeforeUpscale);
            ConfigParser.LoadComboxIndex(comparisonUseScaling);
            ConfigParser.LoadGuiElement(modelSelectAutoExpand);
            ConfigParser.LoadGuiElement(startMaximized);

            // ESRGAN Pytorch
            ConfigParser.LoadComboxIndex(esrganPytorchPythonRuntime);
            ConfigParser.LoadComboxIndex(esrganPytorchAlphaMode);
            ConfigParser.LoadComboxIndex(esrganPytorchAlphaDepth);
            ConfigParser.LoadComboxIndex(esrganPytorchSeamlessMode);
            ConfigParser.LoadGuiElement(esrganPytorchGpuId);
            ConfigParser.LoadGuiElement(esrganPytorchMultiGpu);
            ConfigParser.LoadGuiElement(esrganPytorchCpu);
            ConfigParser.LoadGuiElement(esrganPytorchFp16);

            // ESRGAN NCNN
            ConfigParser.LoadGuiElement(esrganNcnnTilesize);
            ConfigParser.LoadGuiElement(esrganNcnnTta);
            ConfigParser.LoadGuiElement(esrganNcnnGpu);

            // RealESRGAN NCNN
            ConfigParser.LoadGuiElement(realEsrganNcnnTilesize);
            ConfigParser.LoadGuiElement(realEsrganNcnnTta);
            ConfigParser.LoadGuiElement(realEsrganNcnnGpus);

            // Formats
            ConfigParser.LoadGuiElement(jpegQ);
            ConfigParser.LoadGuiElement(webpQ);
            ConfigParser.LoadGuiElement(dxtMode);
            ConfigParser.LoadGuiElement(ddsEnableMips);
            ConfigParser.LoadGuiElement(flipTga);
            ConfigParser.LoadGuiElement(useMozJpeg);

            // Video
            ConfigParser.LoadGuiElement(crf);
            ConfigParser.LoadGuiElement(h265);
            ConfigParser.LoadGuiElement(gifskiQ);
            ConfigParser.LoadGuiElement(vidEnableAudio);

            // Debug
            ConfigParser.LoadGuiElement(logIo);
            ConfigParser.LoadGuiElement(logStatus);
            ConfigParser.LoadComboxIndex(cmdDebugMode);
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
            ConfigParser.SaveGuiElement(modelPath);
            ConfigParser.SaveGuiElement(alphaBgColor);
            ConfigParser.SaveGuiElement(jpegExtension);
            ConfigParser.SaveComboxIndex(previewFormat);
            ConfigParser.SaveGuiElement(reloadImageBeforeUpscale);
            ConfigParser.SaveComboxIndex(comparisonUseScaling);
            ConfigParser.SaveGuiElement(modelSelectAutoExpand);
            ConfigParser.SaveGuiElement(startMaximized);

            // ESRGAN Pytorch
            ConfigParser.SaveComboxIndex(esrganPytorchPythonRuntime);
            ConfigParser.SaveComboxIndex(esrganPytorchAlphaMode);
            ConfigParser.SaveComboxIndex(esrganPytorchAlphaDepth);
            ConfigParser.SaveComboxIndex(esrganPytorchSeamlessMode);
            ConfigParser.SaveGuiElement(esrganPytorchGpuId);
            ConfigParser.SaveGuiElement(esrganPytorchMultiGpu);
            ConfigParser.SaveGuiElement(esrganPytorchCpu);
            ConfigParser.SaveGuiElement(esrganPytorchFp16);

            // ESRGAN NCNN
            ConfigParser.SaveGuiElement(esrganNcnnTilesize);
            ConfigParser.SaveGuiElement(esrganNcnnTta);
            ConfigParser.SaveGuiElement(esrganNcnnGpu);

            // RealESRGAN NCNN
            ConfigParser.SaveGuiElement(realEsrganNcnnTilesize);
            ConfigParser.SaveGuiElement(realEsrganNcnnTta);
            ConfigParser.SaveGuiElement(realEsrganNcnnGpus);

            // Formats
            ConfigParser.SaveGuiElement(jpegQ, ConfigParser.StringMode.Int);
            ConfigParser.SaveGuiElement(webpQ, ConfigParser.StringMode.Int);
            ConfigParser.SaveGuiElement(dxtMode);
            ConfigParser.SaveGuiElement(ddsEnableMips);
            ConfigParser.SaveGuiElement(flipTga);
            ConfigParser.SaveGuiElement(useMozJpeg);
            // Video

            ConfigParser.SaveGuiElement(crf);
            ConfigParser.SaveGuiElement(h265);
            ConfigParser.SaveGuiElement(gifskiQ);
            ConfigParser.SaveGuiElement(vidEnableAudio);

            // Debug
            ConfigParser.SaveGuiElement(logIo);
            ConfigParser.SaveGuiElement(logStatus);
            ConfigParser.SaveComboxIndex(cmdDebugMode);
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
                ConfigParser.LoadComboxIndex(esrganPytorchPythonRuntime);
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