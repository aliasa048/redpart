using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.Tag
{
    public class TagCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
