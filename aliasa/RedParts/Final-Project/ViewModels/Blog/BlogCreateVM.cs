using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.Blog
{
    public class BlogCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Creator { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public string Intro { get; set; }
        public int BlogCategoryId { get; set; }
        public int TagId { get; set; }
        public List<Models.Tag> Tag { get; set; }
        public IEnumerable<int> Blog_TagList { get; set; }
    }
}
