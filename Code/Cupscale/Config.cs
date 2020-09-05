using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cupscale.IO;

namespace Cupscale
{
	internal class Config
	{
		private static string configPath;

		private static string[] cachedLines;

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

		private static string WriteDefaultValIfExists(string key)
		{
			return key switch
			{
				"esrganPath" => WriteDefault("esrganPath", ShippedEsrgan.path), 
				"tilesize" => WriteDefault("tilesize", "512"), 
				"alpha" => WriteDefault("alpha", "False"),
				"alphaBgColor" => WriteDefault("alphaBgColor", "000000FF"),
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
	}
}
