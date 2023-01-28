using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class BlogTag : BaseEntity
    {

        public int TagId { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }
        public Tag Tag { get; set; }
    }
}
