using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Product
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }

    }
}
