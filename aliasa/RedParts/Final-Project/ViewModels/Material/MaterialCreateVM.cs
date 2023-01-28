using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Material
{
    public class MaterialCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
