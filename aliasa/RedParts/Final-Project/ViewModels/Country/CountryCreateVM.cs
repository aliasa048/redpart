using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Country
{
    public class CountryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
