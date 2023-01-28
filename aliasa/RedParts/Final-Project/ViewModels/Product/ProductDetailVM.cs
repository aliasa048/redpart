using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Product
{
    public class ProductDetailVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockCount { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string CategoryName { get; set; }
        public int SellingCount { get; set; }
        public int MaterialId { get; set; }
        public List<Models.Material> Materials { get; set; }
        public IEnumerable<int> ProductMaterialList { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
