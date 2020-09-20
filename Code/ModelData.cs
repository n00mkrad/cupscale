using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale
{
    struct ModelData
    {
        public string model1Name;
        public string model2Name;
        public string model1Path;
        public string model2Path;
        public enum ModelMode { Single, Interp, Chain }
        public ModelMode mode;
        public int interp;

        public ModelData(string model1, string model2, ModelMode modelMode, int interpolation = 0)  
        {
            model1Name = Path.GetFileNameWithoutExtension(model1);
            model2Name = Path.GetFileNameWithoutExtension(model2);
            model1Path = model1;
            model2Path = model2;
            mode = modelMode;
            interp = interpolation;
        }
    }
}
