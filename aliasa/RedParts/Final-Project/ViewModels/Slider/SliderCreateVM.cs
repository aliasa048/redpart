using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
