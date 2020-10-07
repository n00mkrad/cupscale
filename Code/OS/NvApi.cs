using NvAPIWrapper;
using NvAPIWrapper.GPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.OS
{
    class NvApi
    {
        static PhysicalGPU gpu;
        static float vramGb;
        static float vramFreeGb;

        public static void Init ()
        {
            NVIDIA.Initialize();
            PhysicalGPU[] gpus = PhysicalGPU.GetPhysicalGPUs();
            if (gpus.Length == 0)
                return;
            gpu = gpus[0];

            RefreshVram();
            RefreshLoop();
        }

        public static void RefreshVram ()
        {
            if (Form.ActiveForm != Program.mainForm || gpu == null)    // Don't refresh if not in focus or no GPU detected
                return;
            vramGb = (gpu.MemoryInformation.AvailableDedicatedVideoMemoryInkB / 1000f / 1024f);
            vramFreeGb = (gpu.MemoryInformation.CurrentAvailableDedicatedVideoMemoryInkB / 1000f / 1024f);
            Program.mainForm.SetVramLabel($"{gpu.FullName}: {vramFreeGb.ToString("0.00")} GB VRAM available of {vramGb.ToString("0.00")} GB");
        }

        public static async void RefreshLoop ()
        {
            RefreshVram();
            await Task.Delay(1000);
            RefreshLoop();
        }
    }
}
