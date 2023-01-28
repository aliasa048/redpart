using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Product
{
    public class ProductCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StockCount { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
        public int MaterialsId { get; set; }
        public List<Models.Material> Materials { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public int CountryId { get; set; }

    }
}
