using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Employee
{
    public class EmployeeEditVM
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
