using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class BlogDetVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public string Image { get; set; }
        public IEnumerable<Models.Blog> blogs { get; set; }
        public List<Models.Tag> Tags { get; set; }
        public DateTime Createdate { get; set; }
        public IEnumerable<Models.Blog> RecentPosts { get; set; }
        public IEnumerable<Models.BlogCategory> Categories { get; set; }
        public IEnumerable<Models.Tag> AllTag { get; set; }
    }
}
