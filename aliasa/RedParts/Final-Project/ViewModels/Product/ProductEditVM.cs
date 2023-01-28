using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Product
{
    public class ProductEditVM
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int Stock_Count { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
