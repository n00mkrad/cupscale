using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.ImageUtils
{
    class Filters
    {
        public static Filter mitchell = new Filter { Name = "Mitchell", Alias = "Mitchell" };
        public static Filter bicubic = new Filter { Name = "Catrom", Alias = "Bicubic" };
        public static Filter nearest = new Filter { Name = "Point", Alias = "Nearest Neighbor" };
        public static Filter lanczos = new Filter { Name = "Lanczos", Alias = "Lanczos" };
        //public static Filter lanczos2 = new Filter { Name = "Lanczos2", Alias = "Lanczos 2" };
        //public static Filter lanczos2Sharp = new Filter { Name = "Lanczos2Sharp", Alias = "Lanczos 2 Sharp" };

        public static List<Filter> allFilters = new List<Filter> { mitchell, bicubic, nearest, lanczos };
        public static List<Filter> previewFilters = new List<Filter> { bicubic, nearest };
        public static List<Filter> resizeFilters = new List<Filter> { mitchell, bicubic, nearest, lanczos };

        public class Filter
        {
            public string Name = "";
            public string Alias = "";
        }

        public static Filter GetFilter(string alias)
        {
            foreach(Filter f in allFilters)
            {
                if (f.Alias == alias)
                    return f;
            }

            return mitchell;
        }

        public static ImageMagick.FilterType GetMagickFilter(string alias)
        {
            return (ImageMagick.FilterType)Enum.Parse(typeof(ImageMagick.FilterType), GetFilter(alias).Name);
        }

        public static ImageMagick.FilterType GetMagickFilter(Filter filter)
        {
            return (ImageMagick.FilterType)Enum.Parse(typeof(ImageMagick.FilterType), filter.Name);
        }
    }
}
