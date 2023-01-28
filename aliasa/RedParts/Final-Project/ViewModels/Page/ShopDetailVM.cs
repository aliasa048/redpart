using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class ShopDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }   
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string MainImage { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Models.Product> FeaturedProducts { get; set; }
        public int CatId { get; set; }
        public List<Models.Material> Materials { get; set; }
        public IEnumerable<int> ProductMaterial { get; set; }
    }
}
