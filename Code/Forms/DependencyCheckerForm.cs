using Cupscale.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.Forms
{
    public partial class DependencyCheckerForm : Form
    {
        Stopwatch sw = new Stopwatch();

        bool gpuAvail;
        bool nvGpuAvail;
        bool sysPyAvail;
        bool embedPyAvail;
        bool torchAvail;
        bool cv2Avail;

        public DependencyCheckerForm(bool openInstaller = false)
        {
            InitializeComponent();
            if (openInstaller)
                tabList1.SelectedIndex = 1;
        }

        private async void DependencyCheckerForm_Load(object sender, EventArgs e)
        {
            
        }

        public async Task Refresh ()
        {
            if (sw.ElapsedMilliseconds < 1000 && sw.ElapsedMilliseconds != 0)
            {
                Logger.Log($"[DepCheck] Skipping refresh - Only {sw.ElapsedMilliseconds}ms have passed since last refresh!");
                return;
            }

            sw.Restart();
            Logger.Log("[DepCheck] Refreshing...");

            gpuAvail = false;
            nvGpuAvail = false;
            sysPyAvail = false;
            embedPyAvail = false;
            torchAvail = false;
            cv2Avail = false;

            SetChecking(gpu);
            if (HasGpu())
            {
                SetGreen(gpu, "Available");
                gpuAvail = true;
            }
            else
            {
                SetRed(gpu);
            }

            await Task.Delay(10);

            SetChecking(nvGpu);
            string nvGpuName = NvApi.GetGpuName().Replace("GeForce ", "");
            Logger.Log("[DepCheck] GPU Name: " + nvGpuName);
            if (!string.IsNullOrWhiteSpace(nvGpuName))
            {
                SetGreen(nvGpu, nvGpuName);
                nvGpuAvail = true;
            }
            else
            {
                SetRed(nvGpu);
            }

            await Task.Delay(10);

            SetChecking(sysPython);
            string sysPyVer = GetSysPyVersion();
            if (!string.IsNullOrWhiteSpace(sysPyVer) && !sysPyVer.ToLower().Contains("not found") && sysPyVer.Length <= 35)
            {
                SetGreen(sysPython, sysPyVer);
                sysPyAvail = true;
            }
            else
            {
                SetRed(sysPython);
            }

            await Task.Delay(10);

            SetChecking(embedPython);
            string embedPyVer = GetEmbedPyVersion();
            if (!string.IsNullOrWhiteSpace(embedPyVer) && !embedPyVer.ToLower().Contains("not found") && embedPyVer.Length <= 35)
            {
                SetGreen(embedPython, embedPyVer);
                embedPyAvail = true;
            }
            else
            {
                SetRed(embedPython);
            }

            await Task.Delay(10);

            SetChecking(torch);
            string torchVer = GetPytorchVer();
            if (!string.IsNullOrWhiteSpace(torchVer) && torchVer.Length <= 35)
            {
                SetGreen(torch, torchVer);
                torchAvail = true;
            }
            else
            {
                SetRed(torch);
            }

            await Task.Delay(10);

            SetChecking(cv2);
            string cv2Ver = GetOpenCvVer();
            if (!string.IsNullOrWhiteSpace(cv2Ver) && !cv2Ver.ToLower().Contains("ModuleNotFoundError") && cv2Ver.Length <= 35)
            {
                SetGreen(cv2, cv2Ver);
                cv2Avail = true;
            }
            else
            {
                SetRed(cv2);
            }

            RefreshAvailOptions();
        }

        void RefreshAvailOptions ()
        {
            bool hasAnyPy = sysPyAvail || embedPyAvail;
            bool hasPyDepends = torchAvail && cv2Avail;

            if(hasAnyPy && hasPyDepends)
            {
                SetGreen(cpuUpscaling, "Available");
                if (nvGpuAvail)
                    SetGreen(cudaUpscaling, "Available");
                else
                    SetRed(cudaUpscaling, "No Nvidia GPU");
            }
            else
            {
                SetRed(cpuUpscaling, "Missing Dependencies");
                SetRed(cudaUpscaling, "Missing Dependencies");
            }

            if(gpuAvail)
                SetGreen(ncnnUpscaling, "Available");
            else
                SetRed(ncnnUpscaling, "Not Available");
        }

        void SetChecking(Label l)
        {
            l.Text = "Checking...";
            l.ForeColor = Color.Silver;
        }

        void SetGreen(Label l, string t)
        {
            l.Text = t;
            l.ForeColor = Color.Lime;
        }

        void SetRed (Label l, string t = "Not Found")
        {
            l.Text = t;
            l.ForeColor = Color.Red;
        }

        bool HasGpu ()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        graphicsCard = property.Value.ToString();
                        if (string.IsNullOrWhiteSpace(graphicsCard) || graphicsCard.ToLower().Contains("microsoft"))
                            return false;
                        Logger.Log("[DepCheck] Found GPU: " + graphicsCard);
                        return true;
                    }
                }
            }
            Logger.Log("[DepCheck] No GPU found!");
            return false;
        }

        string GetSysPyVersion ()
        {
            string pythonOut = GetSysPythonOutput();
            Logger.Log("[DepCheck] System Python Check Output: " + pythonOut.Trim());
            try
            {
                string ver = pythonOut.Split('(')[0].Trim();
                Logger.Log("[DepCheck] Sys Python Ver: " + ver);
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
            Logger.Log("[DepCheck] Embed Python Check Output: " + pythonOut.Trim());
            try
            {
                string ver = pythonOut.Split('(')[0].Trim();
                Logger.Log("[DepCheck] Embed Python Ver: " + ver);
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
            Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
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
            py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyCmd() + " -V";
            Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
            return output;
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
                py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyCmd() + " -c \"import torch; print(torch.__version__)\"";
                Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
                py.Start();
                py.WaitForExit();
                string output = py.StandardOutput.ReadToEnd();
                string err = py.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
                Logger.Log("[DepCheck] Pytorch Check Output: " + output.Trim());
                return output;
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
                py.StartInfo.Arguments = "/C " + EmbeddedPython.GetPyCmd() + " -c \"import cv2; print(cv2.__version__)\"";
                Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
                py.Start();
                py.WaitForExit();
                string output = py.StandardOutput.ReadToEnd();
                string err = py.StandardError.ReadToEnd();
                if(!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
                Logger.Log("[DepCheck] CV2 Check Output: " + output.Trim());
                return output;
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
