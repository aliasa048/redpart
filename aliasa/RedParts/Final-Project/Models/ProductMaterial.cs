using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class ProductMaterial : BaseEntity
    {
        public int MaterialId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Material material { get; set; }
    }
}
