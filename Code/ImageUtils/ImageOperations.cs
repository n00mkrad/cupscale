using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class ImageOperations
    {
		public static Image Scale (Image img, float scale = 1f, InterpolationMode filtering = InterpolationMode.NearestNeighbor)
		{
			var destImage = new Bitmap((int)Math.Round(img.Width * scale), (int)Math.Round(img.Height * scale));

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = filtering;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				graphics.DrawImage(img, 0, 0, destImage.Width, destImage.Height);     // Scale up
			}

			return destImage;
		}
	}
}
