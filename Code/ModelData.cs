using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale
{
    struct ModelData
    {
        public string model1;
        public string model2;
        public enum ModelMode { Single, Interp, Chain }
        public ModelMode mode;
        public int interp;

        public ModelData(string model1Name, string model2Name, ModelMode modelMode, int interpolation = 0)  
        {
            model1 = model1Name;
            model2 = model2Name;
            mode = modelMode;
            interp = interpolation;
        }
    }
}
