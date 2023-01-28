using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.ProducrCategory
{
    public class ProductCategoryUpdateVM
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
