using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Employee : BaseEntity
    {
        public string FulLName { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
    }
}
