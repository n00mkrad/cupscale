using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Implementations
{
    class Imps
    {
        public static List<Implementation> impList = new List<Implementation>();

        public static Implementation esrganPytorch = new Implementation
        { name="ESRGAN (Pytorch)", dir = "esrgan-pytorch", supportsInterp = true, supportsChain = true };

        public static Implementation esrganNcnn = new Implementation 
        { name = "ESRGAN (NCNN)", dir = "esrgan-ncnn", supportsInterp = false, supportsChain = false };

        public static Implementation realEsrganNcnn = new Implementation 
        { name = "RealESRGAN (NCNN)", dir = "realesrgan-ncnn", supportsInterp = false, supportsChain = false };

        public static void Init()
        {
            impList.Clear();
            impList.Add(esrganPytorch);
            impList.Add(esrganNcnn);
            impList.Add(realEsrganNcnn);
        }
    }
}
