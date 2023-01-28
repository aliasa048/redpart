using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductMaterial> Materials { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
