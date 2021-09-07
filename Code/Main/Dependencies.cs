using Cupscale.OS;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Main
{
    class Dependencies
    {
        public static bool HasGpu()
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

        public static bool SysPyAvail ()
        {
            string sysPyVer = GetSysPyVersion();

            if (!string.IsNullOrWhiteSpace(sysPyVer) && !sysPyVer.ToLower().Contains("not found") && sysPyVer.Length <= 35)
                return true;

            return false;
        }

        public static string GetSysPyVersion()
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

        public static bool EmbedPyAvail()
        {
            string embedPyVer = GetEmbedPyVersion();

            if (!string.IsNullOrWhiteSpace(embedPyVer) && !embedPyVer.ToLower().Contains("not found") && embedPyVer.Length <= 35)
                return true;

            return false;
        }

        public static string GetEmbedPyVersion()
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

        public static string GetSysPythonOutput()
        {
            Process py = OsUtils.NewProcess(true);
            py.StartInfo.Arguments = "/C python -V";
            Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            return output + "\n" + err;
        }

        public static string GetEmbedPythonOutput()
        {
            Process py = OsUtils.NewProcess(true);
            py.StartInfo.Arguments = "/C " + EmbeddedPython.GetEmbedPyPath().Wrap() + " -V";
            Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
            return output;
        }

        public static string GetPytorchVer()
        {
            try
            {
                Process py = OsUtils.NewProcess(true);
                py.StartInfo.Arguments = "\"/C\" " + EmbeddedPython.GetPyCmd() + " -c \"import torch; print(torch.__version__)\"";
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

        public static string GetOpenCvVer()
        {
            try
            {
                Process py = OsUtils.NewProcess(true);
                py.StartInfo.Arguments = "\"/C\" " + EmbeddedPython.GetPyCmd() + " -c \"import cv2; print(cv2.__version__)\"";
                Logger.Log("[DepCheck] CMD: " + py.StartInfo.Arguments);
                py.Start();
                py.WaitForExit();
                string output = py.StandardOutput.ReadToEnd();
                string err = py.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
                Logger.Log("[DepCheck] CV2 Check Output: " + output.Trim());
                return output;
            }
            catch
            {
                return "";
            }
        }
    }
}
