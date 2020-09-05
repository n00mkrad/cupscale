using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class ImgUtils
    {
        public static int GetScale (Image imgFrom, Image imgTo)
        {
            return (int)Math.Round(GetScaleFloat(imgFrom, imgTo));
        }

        public static float GetScaleFloat(Image imgFrom, Image imgTo)
        {
            return (float)imgTo.Width / (float)imgFrom.Width;
        }
    }
}
