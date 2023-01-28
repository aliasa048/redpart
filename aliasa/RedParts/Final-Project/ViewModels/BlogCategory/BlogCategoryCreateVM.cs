using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.BlogCategory
{
    public class BlogCategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
