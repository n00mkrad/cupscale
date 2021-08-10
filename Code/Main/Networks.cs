using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Main
{
    class Networks
    {
        public static List<AI> networks = new List<AI>();

        public static AI esrganCuda = new AI { supportsModels = true };
        public static AI esrganNcnn = new AI { supportsModels = true };
        public static AI realEsrganNcnn = new AI { supportsModels = false };

        public static void Init()
        {
            networks.Clear();
            networks.Add(esrganCuda);
            networks.Add(esrganNcnn);
            networks.Add(realEsrganNcnn);
        }
    }
}
