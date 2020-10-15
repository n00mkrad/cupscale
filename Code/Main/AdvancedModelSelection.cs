using Cupscale.IO;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Main
{
    class AdvancedModelSelection
    {
        // Models 
        public static string e1m1;
        public static string e1m2;

        public static string e2m1;
        public static string e2m2;

        public static string e3m1;
        public static string e3m2;

        // Interp values
        public static int e1m1i;
        public static int e1m2i;

        public static int e2m1i;
        public static int e2m2i;

        public static int e3m1i;
        public static int e3m2i;

        public static void SavePreset (string name)
        {
            string saveData = $"name|{name}" + Environment.NewLine
                + $"e1m1|{e1m1}" + Environment.NewLine
                + $"e1m1i|{e1m1i}" + Environment.NewLine
                + $"e1m2|{e1m2}" + Environment.NewLine
                + $"e1m2i|{e1m2i}" + Environment.NewLine
                + $"e2m1|{e2m1}" + Environment.NewLine
                + $"e2m1i|{e2m1i}" + Environment.NewLine
                + $"e2m2|{e2m2}" + Environment.NewLine
                + $"e2m2i|{e2m2i}" + Environment.NewLine
                + $"e3m1|{e3m1}" + Environment.NewLine
                + $"e3m1i|{e3m1i}" + Environment.NewLine
                + $"e3m2|{e3m2}" + Environment.NewLine
                + $"e3m2i|{e3m2i}";

            string path = Path.Combine(Paths.presetsPath, name);
            File.WriteAllText(path, saveData);
            Logger.Log("Saved model preset to " + path);
        }

        public static bool LoadPreset(string name)
        {
            string path = Path.Combine(Paths.presetsPath, name);
            if (!File.Exists(path))
                return false;

            string[] saveDataLines = IOUtils.ReadLines(path);
            foreach(string line in saveDataLines)
            {
                string[] keyValuePair = line.Split('|');
                switch (keyValuePair[0])
                {
                    case "e1m1":    e1m1 = keyValuePair[1]; break;
                    case "e1m1i":   e1m1i = keyValuePair[1].GetInt(); break;
                    case "e1m2":    e1m2 = keyValuePair[1]; break;
                    case "e1m2i":   e1m2i = keyValuePair[1].GetInt(); break;

                    case "e2m1":    e2m1 = keyValuePair[1]; break;
                    case "e2m1i":   e2m1i = keyValuePair[1].GetInt(); break;
                    case "e2m2":    e2m2 = keyValuePair[1]; break;
                    case "e2m2i":   e2m2i = keyValuePair[1].GetInt(); break;

                    case "e3m1":    e3m1 = keyValuePair[1]; break;
                    case "e3m1i":   e3m1i = keyValuePair[1].GetInt(); break;
                    case "e3m2":    e3m2 = keyValuePair[1]; break;
                    case "e3m2i":   e3m2i = keyValuePair[1].GetInt(); break;
                }  
            }

            Logger.Log("Loaded model preset " + name);
            return true;
        }

        public static string GetArg (bool joey)
        {
            string arg = "";

            if (joey)
            {
                Logger.Log("e1m1i: " + e1m1i + " e1m2: " + e1m2 + " e1m2i: " + e1m2i);
                arg = e1m1;
                // Add Entry 1
                if (!string.IsNullOrWhiteSpace(e1m2))       // Check if entry 1 has a second model
                    arg += $";{e1m1i}&{e1m2};{e1m2i}";
                // Add Entry 2
                if (!string.IsNullOrWhiteSpace(e2m1))       // Check if entry 2 is used
                {
                    arg += $">{e2m1}";
                    if (!string.IsNullOrWhiteSpace(e2m2))       // Check if entry 2 has a second model
                        arg += $";{e2m1i}&{e2m2};{e2m2i}";
                }
                // Add Entry 3
                if (!string.IsNullOrWhiteSpace(e3m1))       // Check if entry 3 is used
                {
                    arg += $">{e3m1}";
                    if (!string.IsNullOrWhiteSpace(e3m2))       // Check if entry 3 has a second model
                        arg += $";{e3m1i}&{e3m2};{e3m2i}";
                }

                arg = arg.Wrap(true, false);
            }
            else
            {
                arg = $" --model {e1m1.Wrap()}";
                // Add Entry 1
                if (!string.IsNullOrWhiteSpace(e1m2))       // Check if entry 1 has a second model
                    arg += $";{e1m1i};{e1m2.Wrap()};{e1m2i}";
                // Add Entry 2
                if (!string.IsNullOrWhiteSpace(e2m1))       // Check if entry 2 is used
                {
                    arg += $" --postfilter {e2m1.Wrap()}";
                    if (!string.IsNullOrWhiteSpace(e2m2))       // Check if entry 2 has a second model
                        arg += $";{e2m1i};{e2m2.Wrap()};{e2m2i}";
                }
                // Add Entry 3
                if (!string.IsNullOrWhiteSpace(e3m1))       // Check if entry 3 is used
                {
                    arg += $" --postfilter {e3m1.Wrap()}";
                    if (!string.IsNullOrWhiteSpace(e3m2))       // Check if entry 3 has a second model
                        arg += $";{e3m1i};{e3m2.Wrap()};{e3m2i}";
                }
            }

            return arg;
        }
    }
}
