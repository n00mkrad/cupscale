using Cupscale.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.Forms
{
    public partial class DependencyCheckerForm : Form
    {
        public DependencyCheckerForm(bool openInstaller = false)
        {
            InitializeComponent();
            if (openInstaller)
                tabList1.SelectedIndex = 1;
        }

        private async void DependencyCheckerForm_Load(object sender, EventArgs e)
        {
            //await Task.Delay(200);
            //await Refresh();
        }

        public async Task Refresh ()
        {
            string gpuName = NvApi.GetGpuName().Replace("GeForce ", "");
            if (!string.IsNullOrWhiteSpace(gpuName))
            {
                nvGpu.Text = gpuName;
                nvGpu.ForeColor = Color.Lime;
            }

            await Task.Delay(10);

            string sysPyVer = GetSysPyVersion();
            if (!string.IsNullOrWhiteSpace(sysPyVer) && !sysPyVer.ToLower().Contains("not found") && sysPyVer.Length <= 35)
            {
                sysPython.Text = sysPyVer;
                sysPython.ForeColor = Color.Lime;
            }
            else
            {
                SetToNotFound(sysPython);
            }

            await Task.Delay(10);

            string embedPyVer = GetEmbedPyVersion();
            if (!string.IsNullOrWhiteSpace(embedPyVer) && !embedPyVer.ToLower().Contains("not found") && embedPyVer.Length <= 35)
            {
                embedPython.Text = embedPyVer;
                embedPython.ForeColor = Color.Lime;
            }
            else
            {
                SetToNotFound(embedPython);
            }

            await Task.Delay(10);

            string torchVer = GetPytorchVer();
            if (!string.IsNullOrWhiteSpace(torchVer) && torchVer.Length <= 35)
            {
                torch.Text = torchVer;
                torch.ForeColor = Color.Lime;
            }
            else
            {
                SetToNotFound(torch);
            }

            await Task.Delay(10);

            string cv2Ver = GetOpenCvVer();
            if (!string.IsNullOrWhiteSpace(cv2Ver) && !cv2Ver.ToLower().Contains("ModuleNotFoundError") && cv2Ver.Length <= 35)
            {
                cv2.Text = cv2Ver;
                cv2.ForeColor = Color.Lime;
            }
            else
            {
                SetToNotFound(cv2);
            }
        }

        void SetToNotFound (Label l)
        {
            l.Text = "Not Found";
            l.ForeColor = Color.Red;
        }

        string GetSysPyVersion ()
        {
            string pythonOut = GetSysPythonOutput();
            try
            {
                string ver = pythonOut.Split('(')[0].Trim();
                return ver;
            }
            catch
            {
                return "";
            }
        }

        string GetEmbedPyVersion()
        {
            string pythonOut = GetEmbedPythonOutput();
            try
            {
                string ver = pythonOut.Split('(')[0].Trim();
                return ver;
            }
            catch
            {
                return "";
            }
        }

        string GetSysPythonOutput ()
        {
            Process py = new Process();
            py.StartInfo.UseShellExecute = false;
            py.StartInfo.RedirectStandardOutput = true;
            py.StartInfo.RedirectStandardError = true;
            py.StartInfo.CreateNoWindow = true;
            py.StartInfo.FileName = "cmd.exe";
            py.StartInfo.Arguments = "/C python -V";
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            return output + "\n" + err;
        }

        string GetEmbedPythonOutput ()
        {
            Process py = new Process();
            py.StartInfo.UseShellExecute = false;
            py.StartInfo.RedirectStandardOutput = true;
            py.StartInfo.RedirectStandardError = true;
            py.StartInfo.CreateNoWindow = true;
            py.StartInfo.FileName = "cmd.exe";
            py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyPath() + " -V";
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            return output + "\n" + err;
        }

        string GetPytorchVer ()
        {
            try
            {
                Process py = new Process();
                py.StartInfo.UseShellExecute = false;
                py.StartInfo.RedirectStandardOutput = true;
                py.StartInfo.RedirectStandardError = true;
                py.StartInfo.CreateNoWindow = true;
                py.StartInfo.FileName = "cmd.exe";
                if (embedPython.Enabled)
                    py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyPath() + " -c \"import torch; print(torch.__version__)\"";
                else
                    py.StartInfo.Arguments = "/C python -c \"import torch; print(torch.__version__)\"";
                py.Start();
                py.WaitForExit();
                string output = py.StandardOutput.ReadToEnd();
                string err = py.StandardError.ReadToEnd();
                return output + "\n" + err;
            }
            catch
            {
                return "";
            }
        }

        string GetOpenCvVer()
        {
            try
            {
                Process py = new Process();
                py.StartInfo.UseShellExecute = false;
                py.StartInfo.RedirectStandardOutput = true;
                py.StartInfo.RedirectStandardError = true;
                py.StartInfo.CreateNoWindow = true;
                py.StartInfo.FileName = "cmd.exe";
                if (embedPython.Enabled)
                    py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyPath() + " -c \"import cv2; print(cv2.__version__)\"";
                else
                    py.StartInfo.Arguments = "/C python -c \"import cv2; print(cv2.__version__)\"";
                py.Start();
                py.WaitForExit();
                string output = py.StandardOutput.ReadToEnd();
                string err = py.StandardError.ReadToEnd();
                return output + "\n" + err;
            }
            catch
            {
                return "";
            }
        }

        private async void label8_VisibleChanged(object sender, EventArgs e)
        {
            if (!label8.Visible)
                return;
            await Task.Delay(100);
            await Refresh();
        }

        private async void installBtn_Click(object sender, EventArgs e)
        {
            await EmbeddedPython.Download(installerLogBox, installBtn);
        }

        private void DependencyCheckerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!installBtn.Enabled)
                e.Cancel = true;
        }
    }
}
