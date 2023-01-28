using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services;
using Final_Project.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class CatalogController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public CatalogController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            IEnumerable<ProductCategory> categories = await _context.ProductCategories
                .Where(m => !m.IsDeleted)
                .ToListAsync();


            CatalogVM catalog = new CatalogVM
            {
                ProductCategories = categories,
            };

            return View(catalog);
        }
    }
}
