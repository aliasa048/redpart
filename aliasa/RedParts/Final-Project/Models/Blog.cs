using System;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Creator { get; set; }
        public int BlogCategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }

    }
}
