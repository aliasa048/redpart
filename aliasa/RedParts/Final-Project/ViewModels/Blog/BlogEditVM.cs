using Microsoft.AspNetCore.Http;

namespace Final_Project.ViewModels.Blog
{
    public class BlogEditVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public string Intro { get; set; }
        public string Image { get; set; }
        public int BlogCategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
