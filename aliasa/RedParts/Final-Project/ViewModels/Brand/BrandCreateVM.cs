using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Brand
{
    public class BrandCreateVM
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
