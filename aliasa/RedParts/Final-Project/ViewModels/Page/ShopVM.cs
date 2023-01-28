using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class ShopVM
    {
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Models.ProductCategory> ProductCategories { get; set; }
        public IEnumerable<Models.Brand> Brands { get; set; }
        public IEnumerable<Models.Country> Countries { get; set; }
    }
}
