using NvAPIWrapper;
using NvAPIWrapper.GPU;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.OS
{
    class NvApi
    {
        public enum Architecture { Undetected, Fermi, Kepler, Maxwell, Pascal, Turing, Ampere };
        public static List<PhysicalGPU> gpuList = new List<PhysicalGPU>();
        private Dictionary<PhysicalGPU, float> vramTotal = new Dictionary<PhysicalGPU, float>();
        private Dictionary<PhysicalGPU, float> vramAvail = new Dictionary<PhysicalGPU, float>();

        public static async void Init ()
        {
            try
            {
                NVIDIA.Initialize();
                PhysicalGPU[] gpus = PhysicalGPU.GetPhysicalGPUs();

                if (gpus.Length == 0)
                    return;

                gpuList = gpus.ToList();
                List<string> gpuNames = new List<string>();

                foreach (PhysicalGPU gpu in gpus)
                    Logger.Log($"Detected Card: {gpu.FullName} / GPU: {gpu.ArchitectInformation.ShortName} / Arch: {GetArch(gpu)}");

                Logger.Log($"Initialized Nvidia API. GPU{(gpus.Length > 1 ? "s" : "")}: {GetGpuListStr()}");

                while (true)
                {
                    RefreshVram();
                    await Task.Delay(1000);
                }
            }
            catch (Exception e)
            {
                Logger.Log($"Failed to initialize NvApi: {e.Message}\nIgnore this if you don't have an Nvidia GPU.");
            }
        }

        public static string GetGpuListStr ()
        {
            return string.Join(", ", gpuList.Select(x => x.FullName));
        }

        public static bool HasAmpereOrNewer()   // To detect if newer Pytorch version is needed
        {
            foreach (PhysicalGPU gpu in gpuList)
            {
                Architecture arch = GetArch(gpu);

                if (arch == Architecture.Ampere || arch == Architecture.Undetected)
                    return true;
            }

            return false;
        }

        public static Architecture GetArch(PhysicalGPU gpu)
        {
            string gpuCode = gpu.ArchitectInformation.ShortName;

            if (gpuCode.Trim().StartsWith("GF")) return Architecture.Fermi;
            if (gpuCode.Trim().StartsWith("GK")) return Architecture.Kepler;
            if (gpuCode.Trim().StartsWith("GM")) return Architecture.Maxwell;
            if (gpuCode.Trim().StartsWith("GP")) return Architecture.Pascal;
            if (gpuCode.Trim().StartsWith("TU")) return Architecture.Turing;
            if (gpuCode.Trim().StartsWith("GA")) return Architecture.Ampere;

            return Architecture.Undetected;
        }

        public static void RefreshVram ()
        {
            if (Form.ActiveForm != Program.mainForm) // Don't refresh if not in focu
                return;

            List<string> gpusWithVram = new List<string>();

            foreach(PhysicalGPU gpu in gpuList)
            {
                if (gpu == null)
                    continue;

                float vramGb = (gpu.MemoryInformation.AvailableDedicatedVideoMemoryInkB / 1000f / 1024f);
                float vramFreeGb = (gpu.MemoryInformation.CurrentAvailableDedicatedVideoMemoryInkB / 1000f / 1024f);
                string shortenedName = gpu.FullName.Replace("NVIDIA ", "").Replace("AMD ", "");

                gpusWithVram.Add($"{shortenedName}: {vramFreeGb.ToString("0.0")}/{vramGb.ToString("0.0")} GB Free");
            }

            Program.mainForm.SetVramLabel(string.Join(" - ", gpusWithVram), Color.White);
        }

        public static string GetGpuName ()
        {
            try
            {
                NVIDIA.Initialize();
                PhysicalGPU[] gpus = PhysicalGPU.GetPhysicalGPUs();
                if (gpus.Length == 0)
                    return "";

                return gpus[0].FullName;
            }
            catch
            {
                return "";
            }
        }
    }
}
