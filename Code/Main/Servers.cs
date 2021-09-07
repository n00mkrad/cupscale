using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cupscale.Main
{
    class Servers
    {
        public static Server hetznerEu = new Server { name = "Germany (Nürnberg)", host = "nmkd-hz.de", pattern = "https://dl.*" };
        public static Server contaboUs = new Server { name = "USA (St. Louis)", host = "nmkd-cb.de", pattern = "https://dl.*" };

        public static List<Server> serverList = new List<Server> { hetznerEu, contaboUs };

        public static Server closestServer = serverList[0];

        public class Server
        {
            public string name = "";
            public string host = "";
            public string pattern = "*";

            public string GetUrl()
            {
                return pattern.Replace("*", host);
            }
        }

        public static async Task Init(ComboBox comboBox = null)
        {
            Dictionary<string[], long> serversPings = new Dictionary<string[], long>();

            foreach (Server server in serverList)
            {
                try
                {
                    Ping p = new Ping();
                    PingReply replyEur = p.Send(server.host, 2000);
                    serversPings[new string[] { server.name, server.host, server.pattern }] = replyEur.RoundtripTime;
                    Logger.Log($"[Servers] Ping to {server.host}: {replyEur.RoundtripTime} ms", true);
                }
                catch (Exception e)
                {
                    Logger.Log($"[Servers] Failed to ping {server.host}: {e.Message}", true);
                    serversPings[new string[] { server.name, server.host, server.pattern }] = 10000;
                }
            }

            var closest = serversPings.Aggregate((l, r) => l.Value < r.Value ? l : r);
            Logger.Log($"[Servers] Closest Server: {closest.Key[0]} ({closest.Value} ms)", true);
            closestServer = new Server { name = closest.Key[0], host = closest.Key[1], pattern = closest.Key[2] };

            if (comboBox != null)
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    if (comboBox.Items[i].ToString() == closestServer.name)
                        comboBox.SelectedIndex = i;
                }
            }
        }
    }
}
