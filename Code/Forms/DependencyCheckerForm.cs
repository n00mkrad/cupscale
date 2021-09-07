using Cupscale.Main;
using Cupscale.OS;
using Cupscale.UI;
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

        public DependencyCheckerForm(bool openPyInstaller = false, bool startPyInstall = false)
        {
            InitializeComponent();

            if (openPyInstaller)
                tabList1.SelectedIndex = 1;

            if (openPyInstaller && startPyInstall)
                installBtn_Click(null, null);
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

            if (Dependencies.HasGpu())
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

            if (NvApi.gpuList.Count > 0)
            {
                string gpuText = NvApi.GetFirstGpuName().Replace("NVIDIA ", "").Replace("AMD ", "").Replace("GeForce ", "");
                Logger.Log("[DepCheck] First GPU Name: " + gpuText);

                if (NvApi.gpuList.Count > 1)
                    gpuText = $"{gpuText} + {NvApi.gpuList.Count - 1}";

                SetGreen(nvGpu, gpuText);
                nvGpuAvail = true;
            }
            else
            {
                SetRed(nvGpu);
            }

            await Task.Delay(10);

            SetChecking(sysPython);
            string sysPyVer = Dependencies.GetSysPyVersion();

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
            string embedPyVer = Dependencies.GetEmbedPyVersion();

            if (!string.IsNullOrWhiteSpace(embedPyVer) && !embedPyVer.ToLower().Contains("not found") && embedPyVer.Length <= 35)
            {
                SetGreen(embedPython, embedPyVer);
                embedPyAvail = true;
            }
            else
            {
                SetRed(embedPython);
            }

            if (!sysPyAvail && embedPyAvail)
                SetGrey(sysPython, "Not Needed");

            if (!embedPyAvail&& sysPyAvail)
                SetGrey(embedPython, "Not Needed");

            await Task.Delay(10);

            SetChecking(torch);
            string torchVer = Dependencies.GetPytorchVer();

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
            string cv2Ver = Dependencies.GetOpenCvVer();

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

        void SetGrey(Label l, string t = "Not Found")
        {
            l.Text = t;
            l.ForeColor = Color.Gray;
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
