using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class CatalogVM
    {
        public IEnumerable<Models.ProductCategory> ProductCategories { get; set; }
    }
}
