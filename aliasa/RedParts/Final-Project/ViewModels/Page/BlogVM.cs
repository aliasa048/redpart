using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Page
{
    public class BlogVM
    {
        public IEnumerable<Models.Blog> Blogs { get; set; }
        public IEnumerable<Models.Blog> RecentPost { get; set; }
        public IEnumerable<Models.Tag> Tags { get; set; }
        public IEnumerable<Models.BlogCategory> Categories { get; set; }
    }
}
