using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Final_Project.ViewModels.Blog
{
    public class BlogDetailVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public string Intro { get; set; }
        public int BlogCategoryId { get; set; }
        public int TagId { get; set; }
        public List<Models.Tag> Tag { get; set; }
        public IEnumerable<int> Blog_TagList { get; set; }
    }
}
