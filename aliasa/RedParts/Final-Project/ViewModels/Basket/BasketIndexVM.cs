using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels.Basket
{
    public class BasketIndexVM
    {
        public BasketIndexVM()
        {
            BasketProducts = new List<BasketProductVM>();
        }

        public List<BasketProductVM> BasketProducts { get; set; }
    }
}
