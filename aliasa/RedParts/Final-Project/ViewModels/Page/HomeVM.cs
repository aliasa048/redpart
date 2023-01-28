using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class HomeVM
    {
        public IEnumerable<Models.Brand> Brands { get; set; }
        public IEnumerable<Models.ProductCategory> Categories { get; set; }
        public IEnumerable<Models.Slider> Sliders { get; set; }
        public IEnumerable<Models.Service> Services { get; set; }
        public IEnumerable<Models.Product> LastProduct { get; set; }
        public IEnumerable<Models.Product> Product { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Models.Banner> Banners { get; set; }
        public IEnumerable<Models.Blog> Blogs { get; set; }
    }
}
