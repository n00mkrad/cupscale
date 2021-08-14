using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Implementations
{
    class Implementations
    {
        public static List<Implementation> implementations = new List<Implementation>();

        public static Implementation esrganPytorch = new Implementation { dir = "esrgan-pytorch", supportsModels = true };
        public static Implementation esrganNcnn = new Implementation { dir = "esrgan-ncnn", supportsModels = true };
        public static Implementation realEsrganNcnn = new Implementation { dir = "realesrgan-ncnn", supportsModels = false };

        public static void Init()
        {
            implementations.Clear();
            implementations.Add(esrganPytorch);
            implementations.Add(esrganNcnn);
            implementations.Add(realEsrganNcnn);
        }
    }
}
