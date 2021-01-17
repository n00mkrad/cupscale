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

		public static string Get(string key)
		{
			for (int i = 0; i < cachedLines.Length; i++)
			{
				string[] keyValuePair = cachedLines[i].Split('|');
				if (keyValuePair[0] == key)
					return keyValuePair[1];
			}
			return WriteDefaultValIfExists(key);
		}

		public static bool GetBool (string key)
        {
			return bool.Parse(Get(key));
        }

		public static int GetInt (string key)
		{
			for (int i = 0; i < cachedLines.Length; i++)
			{
				string[] keyValuePair = cachedLines[i].Split('|');
				if (keyValuePair[0] == key)
					return int.Parse(keyValuePair[1].Trim());
			}
			return int.Parse(WriteDefaultValIfExists(key).Trim());
		}

		private static string WriteDefaultValIfExists(string key)
		{
			return key switch
			{
				"esrganPath" => WriteDefault(key, Installer.path),
				"esrganVer" => WriteDefault(key, "0"), 
				"tilesize" => WriteDefault(key, "1024"),
				"alpha" => WriteDefault(key, "False"),
				"alphaMode" => WriteDefault(key, "1"),
				"alphaDepth" => WriteDefault(key, "0"),
				"seamlessMode" => WriteDefault(key, "0"),
				"alphaBgColor" => WriteDefault(key, "000000FF"),
				"jpegExtension" => WriteDefault(key, "jpg"),
				"jpegQ" => WriteDefault(key, "95"),
				"webpQ" => WriteDefault(key, "95"),
				"dxtMode" => WriteDefault(key, "BC1 (DXT1)"),
				"ddsEnableMips" => WriteDefault(key, "True"),
				"previewFormat" => WriteDefault(key, "0"),
				"cudaFallback" => WriteDefault(key, "0"),
				"gpuId" => WriteDefault(key, "0"),
				"reloadImageBeforeUpscale" => WriteDefault(key, "False"),
				"cmdDebug" => WriteDefault(key, "False"),
				"flipTga" => WriteDefault(key, "True"),
				"logIo" => WriteDefault(key, "False"),
				"logStatus" => WriteDefault(key, "False"),
				"cmdDebugMode" => WriteDefault(key, "0"),
				"pythonRuntime" => WriteDefault(key, "0"),
				"useMozJpeg" => WriteDefault(key, "True"),
				"comparisonUseScaling" => WriteDefault(key, "0"),
				"joeyAlphaMode" => WriteDefault(key, "1"),
				// Video
				"h265" => WriteDefault(key, "False"),
				"crf" => WriteDefault(key, "18"),
				"gifskiQ" => WriteDefault(key, "100"),
				"vidEnableAudio" => WriteDefault(key, "True"),
				_ => null, 
			};
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
			if(onlyAllowNumbers)
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

		public static void LoadGuiElement (TextBox textbox)
        {
			textbox.Text = Get(textbox.Name);
		}

		public static void LoadGuiElement (CheckBox checkbox)
		{
			checkbox.Checked = bool.Parse(Get(checkbox.Name));
		}

		public static void LoadComboxIndex (ComboBox comboBox)
		{
			comboBox.SelectedIndex = GetInt(comboBox.Name);
		}
	}
}
