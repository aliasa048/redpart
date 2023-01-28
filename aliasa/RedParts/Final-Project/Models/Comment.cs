using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Comment : BaseEntity
    {
        public string CommentDetail { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
