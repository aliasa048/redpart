using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services;
using Final_Project.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class HomeController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public HomeController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            IEnumerable<Brand> brands = await _context.Brands
                .Where(m => !m.IsDeleted)
                .Take(12)
                .ToListAsync();
            IEnumerable<Service> services = await _context.Services
                .Where(m => !m.IsDeleted)
                .Take(4)
                .ToListAsync();
            IEnumerable<ProductCategory> categories = await _context.ProductCategories
                .Where(m => !m.IsDeleted)
                .Take(6)
                .ToListAsync();
            IEnumerable<Slider> sliders = await _context.Sliders
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            IEnumerable<Product> Lastproducts = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m=>m.ProductImage)
                .Include(m=>m.Brand)
                .Include(m=>m.Country)
                .Include(m=>m.ProductCategory)
                .Take(8)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImage)
                .Include(m => m.Brand)
                .Include(m => m.Country)
                .Include(m => m.ProductCategory)
                .Take(8)
                .ToListAsync();
            IEnumerable<Banner> banners = await _context.Banners
                .Where(m => !m.IsDeleted)
                .OrderByDescending(m=>m.Id)
                .Take(2)
                .ToListAsync();
            IEnumerable<Product> product = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImage)
                .Include(m => m.Brand)
                .Include(m => m.Country)
                .Include(m => m.ProductCategory)
                .Take(8)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs
                .Where(m => !m.IsDeleted)
                .Include(m => m.BlogTags)
                .Include(m => m.BlogCategory)
                .Take(8)
                .OrderByDescending(m => m.Id)
                .ToListAsync();


            HomeVM model = new HomeVM
            {
                Brands = brands,
                Categories = categories,
                Sliders = sliders,
                LastProduct= Lastproducts,
                Product = products,
                Banners = banners,
                Products = product,
                Blogs = blogs,
                Services = services,
            };

            return View(model);
        }

        public IActionResult Search(string search)
        {
            List<Product> searchName = _context.Products.Where(s => !s.IsDeleted && s.Name.Trim().Contains(search.Trim())).Include(m => m.ProductImage).ToList();
            return PartialView("_Search", searchName);
        }
    }
}
