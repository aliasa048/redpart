using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string SKU { get; set; }
        public int SellingCount { get; set; }
        public int StockCount { get; set; }
        //public int ProductCategoriesId { get; set; }
        //public int BrandId { get; set; }
        //public int CountriesId { get; set; }

        public int ProductCategoryId { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public Brand Brand { get; set; }
        public Country Country { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<ProductImage> ProductImage { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
