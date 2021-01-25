using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Cupscale.IO;
using Cupscale.UI;

namespace Cupscale
{
    internal class Config
    {
        private static string configPath;

        private static string[] cachedLines;

        public static bool disable;

        public static void Init()
        {
            configPath = Path.Combine(IOUtils.GetAppDataDir(), "config.ini");
            if (!File.Exists(configPath))
            {
                File.Create(configPath).Close();
            }
            Reload();
        }

        public static void Set(string key, string value)
        {
            if (disable) return;

            string[] lines = File.ReadAllLines(configPath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split('|')[0] == key)
                {
                    lines[i] = key + "|" + value;
                    File.WriteAllLines(configPath, lines);
                    cachedLines = lines;
                    return;
                }
            }
            List<string> list = lines.ToList();
            list.Add(key + "|" + value);
            File.WriteAllLines(configPath, list.ToArray());
            cachedLines = list.ToArray();
        }

        public static string Get(string key, Type type = Type.String)
        {
            try
            {
                for (int i = 0; i < cachedLines.Length; i++)
                {
                    string[] keyValuePair = cachedLines[i].Split('|');
                    if (keyValuePair[0] == key && !string.IsNullOrWhiteSpace(keyValuePair[1]))
                        return keyValuePair[1];
                }
                return WriteDefaultValIfExists(key, type);
            }
            catch (Exception e)
            {
                Logger.Log($"Failed to get {key.Wrap()} from config! {e.Message}");
            }
            return null;
        }

        public static bool GetBool(string key)
        {
            try
            {
                return bool.Parse(Get(key));
            }
            catch (Exception e)
            {
                Logger.Log($"Failed to parse value of key '{key}' ('{Get(key)}') to bool: {e.Message} - Default to False");
                return false;
            }
        }

        public static bool GetBool(string key, bool defaultVal)
        {
            WriteIfDoesntExist(key, (defaultVal ? "True" : "False"));
            return bool.Parse(Get(key, Type.Bool));
        }

        public static int GetInt(string key)
        {
            for (int i = 0; i < cachedLines.Length; i++)
            {
                string[] keyValuePair = cachedLines[i].Split('|');
                if (keyValuePair[0] == key)
                    return int.Parse(keyValuePair[1].Trim());
            }
            return int.Parse(WriteDefaultValIfExists(key, Type.Int).Trim());
        }

        static void WriteIfDoesntExist(string key, string val)
        {
            Logger.Log("WriteIfDoesntExist: " + key + " - " + val);
            foreach (string line in cachedLines)
                if (line.Contains(key + "|"))
                    return;
            Set(key, val);
            Logger.Log("WriteIfDoesntExist: Set()");
        }

        public enum Type { String, Int, Float, Bool }
        private static string WriteDefaultValIfExists(string key, Type type)
        {
            if (key == "esrganPath") return WriteDefault(key, Installer.path);
            if (key == "esrganVer") return WriteDefault(key, "0");
            if (key == "tilesize") return WriteDefault(key, "1024");
            if (key == "alpha") return WriteDefault(key, "False");
            if (key == "alphaMode") return WriteDefault(key, "1");
            if (key == "alphaDepth") return WriteDefault(key, "0");
            if (key == "seamlessMode") return WriteDefault(key, "0");
            if (key == "alphaBgColor") return WriteDefault(key, "000000FF");
            if (key == "jpegExtension") return WriteDefault(key, "jpg");
            if (key == "jpegQ") return WriteDefault(key, "95");
            if (key == "webpQ") return WriteDefault(key, "95");
            if (key == "dxtMode") return WriteDefault(key, "BC1 (DXT1)");
            if (key == "ddsEnableMips") return WriteDefault(key, "True");
            if (key == "previewFormat") return WriteDefault(key, "0");
            if (key == "cudaFallback") return WriteDefault(key, "0");
            if (key == "gpuId") return WriteDefault(key, "0");
            if (key == "reloadImageBeforeUpscale") return WriteDefault(key, "False");
            if (key == "cmdDebug") return WriteDefault(key, "False");
            if (key == "flipTga") return WriteDefault(key, "True");
            if (key == "logIo") return WriteDefault(key, "False");
            if (key == "logStatus") return WriteDefault(key, "False");
            if (key == "cmdDebugMode") return WriteDefault(key, "0");
            if (key == "pythonRuntime") return WriteDefault(key, "0");
            if (key == "useMozJpeg") return WriteDefault(key, "True");
            if (key == "comparisonUseScaling") return WriteDefault(key, "0");
            if (key == "joeyAlphaMode") return WriteDefault(key, "1");
            if (key == "modelSelectAutoExpand") return WriteDefault(key, "True");
            // Video
            if (key == "h265") return WriteDefault(key, "False");
            if (key == "crf") return WriteDefault(key, "18");
            if (key == "gifskiQ") return WriteDefault(key, "100");
            if (key == "vidEnableAudio") return WriteDefault(key, "True");

            if (type == Type.Int || type == Type.Float) return WriteDefault(key, "0");     // Write default int/float (0)
            if (type == Type.Bool) return WriteDefault(key, "False");     // Write default bool (False)
            return WriteDefault(key, "0");
        }

        private static string WriteDefault(string key, string def)
        {
            Set(key, def);
            return def;
        }

        private static void Reload()
        {
            cachedLines = File.ReadAllLines(configPath);
        }

        public static void SaveGuiElement(TextBox textbox, bool onlyAllowNumbers = false)
        {
            if (onlyAllowNumbers)
                Set(textbox.Name, textbox.Text.GetInt().ToString());
            else
                Set(textbox.Name, textbox.Text);
        }

        public static void SaveGuiElement(ComboBox comboBox, bool onlyAllowNumbers = false)
        {
            if (onlyAllowNumbers)
                Set(comboBox.Name, comboBox.Text.GetInt().ToString());
            else
                Set(comboBox.Name, comboBox.Text);
        }

        public static void SaveGuiElement(CheckBox checkbox)
        {
            Set(checkbox.Name, checkbox.Checked.ToString());
        }

        public static void SaveComboxIndex(ComboBox comboBox)
        {
            Set(comboBox.Name, comboBox.SelectedIndex.ToString());
        }

        public static void LoadGuiElement(ComboBox comboBox)
        {
            comboBox.Text = Get(comboBox.Name);
        }

        public static void LoadGuiElement(TextBox textbox)
        {
            textbox.Text = Get(textbox.Name);
        }

        public static void LoadGuiElement(CheckBox checkbox)
        {
            checkbox.Checked = GetBool(checkbox.Name);
        }

        public static void LoadComboxIndex(ComboBox comboBox)
        {
            comboBox.SelectedIndex = GetInt(comboBox.Name);
        }
    }
}
