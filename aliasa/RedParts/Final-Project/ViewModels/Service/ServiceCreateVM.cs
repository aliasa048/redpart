using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.Service
{
    public class ServiceCreateVM
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
