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

        public static Implementation esrganPytorch = new Implementation
        { name="ESRGAN (Pytorch)", dir = "esrgan-pytorch", supportsInterp = true, supportsChain = true };

        public static Implementation esrganNcnn = new Implementation 
        { name = "ESRGAN (NCNN)", dir = "esrgan-ncnn", supportsInterp = false, supportsChain = false };

        public static Implementation realEsrganNcnn = new Implementation 
        { name = "RealESRGAN (NCNN)", dir = "realesrgan-ncnn", supportsInterp = false, supportsChain = false };

        public static void Init()
        {
            implementations.Clear();
            implementations.Add(esrganPytorch);
            implementations.Add(esrganNcnn);
            implementations.Add(realEsrganNcnn);
        }
    }
}
