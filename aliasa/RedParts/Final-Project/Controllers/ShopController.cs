using Final_Project.Data;
using Final_Project.Helper;
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
    public class ShopController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public ShopController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int? catId, int? brandId, int? caId, int page = 1, int take = 8)
        {
            if (catId is null)
            {
                if (brandId is null)
                {
                    if (caId is null)
                    {
                        List<Product> products = await _context.Products
                          .Where(m => !m.IsDeleted)
                          .Include(m => m.Brand)
                          .Include(m => m.ProductImage)
                          .Skip((page * take) - take)
                          .Take(take)
                          .ToListAsync();

                        IEnumerable<Brand> brands = await _context.Brands
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();
                        IEnumerable<ProductCategory> categories = await _context.ProductCategories
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();
                        IEnumerable<Country> countries = await _context.Countries
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();

                        ViewBag.take = take;

                        List<ShopVM> shopVMs = new List<ShopVM>();

                        ShopVM model = new ShopVM
                        {
                            Products = products.ToList(),
                            Brands = brands,
                            ProductCategories = categories,
                            Countries = countries,
                        };

                        shopVMs.Add(model);

                        int count = await GetPageCount(take);

                        Paginate<ShopVM> result = new Paginate<ShopVM>(shopVMs, page, count);

                        return View(result);
                    }
                    else
                    {
                        List<Product> products = await _context.Products
                             .Where(m => !m.IsDeleted && m.CountryId == caId)
                             .Include(m => m.Brand)
                             .Include(m => m.ProductCategory)
                             .Include(m => m.ProductImage)
                             .Skip((page * take) - take)
                             .Take(take)
                             .ToListAsync();

                        IEnumerable<Brand> brands = await _context.Brands
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();
                        IEnumerable<ProductCategory> categories = await _context.ProductCategories
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();
                        IEnumerable<Country> countries = await _context.Countries
                            .Where(m => !m.IsDeleted)
                            .ToListAsync();

                        ViewBag.take = take;

                        List<ShopVM> shopVMs = new List<ShopVM>();

                        ShopVM model = new ShopVM
                        {
                            Products = products.ToList(),
                            Brands = brands,
                            ProductCategories = categories,
                            Countries = countries,
                        };

                        shopVMs.Add(model);

                        int count = await GetPageCount(take);

                        Paginate<ShopVM> result = new Paginate<ShopVM>(shopVMs, page, count);

                        return View(result);
                    }

                   
                }
                else
                {
                    List<Product> products = await _context.Products
                      .Where(m => !m.IsDeleted && m.BrandId == brandId)
                      .Include(m => m.Brand)
                      .Include(m => m.ProductCategory)
                      .Include(m => m.ProductImage)
                      .Skip((page * take) - take)
                      .Take(take)
                      .ToListAsync();

                    IEnumerable<Brand> brands = await _context.Brands
                        .Where(m => !m.IsDeleted)
                        .ToListAsync();
                    IEnumerable<ProductCategory> categories = await _context.ProductCategories
                        .Where(m => !m.IsDeleted)
                        .ToListAsync();
                    IEnumerable<Country> countries = await _context.Countries
                        .Where(m => !m.IsDeleted)
                        .ToListAsync();


                    ViewBag.take = take;

                    List<ShopVM> shopVMs = new List<ShopVM>();

                    ShopVM model = new ShopVM
                    {
                        Products = products.ToList(),
                        Brands = brands,
                        ProductCategories = categories,
                        Countries = countries,
                    };

                    shopVMs.Add(model);

                    int count = await GetPageCount(take);

                    Paginate<ShopVM> result = new Paginate<ShopVM>(shopVMs, page, count);

                    return View(result);
                }

                
            }
            else
            {
                List<Product> products = await _context.Products
                   .Where(m => !m.IsDeleted && m.ProductCategoryId == catId)
                   .Include(m => m.Brand)
                   .Include(m=>m.ProductCategory)
                   .Include(m => m.ProductImage)
                   .Skip((page * take) - take)
                   .Take(take)
                   .ToListAsync();

                IEnumerable<Brand> brands = await _context.Brands
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();
                IEnumerable<ProductCategory> categories = await _context.ProductCategories
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();
                IEnumerable<Country> countries = await _context.Countries
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();

                ViewBag.take = take;

                List<ShopVM> shopVMs = new List<ShopVM>();

                ShopVM model = new ShopVM
                {
                    Products = products.ToList(),
                    Brands = brands,
                    ProductCategories = categories,
                    Countries = countries,
                };

                shopVMs.Add(model);

                int count = await GetPageCount(take);

                Paginate<ShopVM> result = new Paginate<ShopVM>(shopVMs, page, count);

                return View(result);
            }
           
        }
        #endregion

        #region Services
        public async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products.Where(m => !m.IsDeleted).CountAsync();
            return (int)Math.Ceiling((decimal)productCount / take);
        }
        #endregion

    }
}
