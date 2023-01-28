using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.ProducrCategory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductCategoryController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public ProductCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<ProductCategory> categories = await _context.ProductCategories
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<ProductCategoryListVM> mapDatas = GetMapDatas(categories);

            int count = await GetPageCount(take);

            Paginate<ProductCategoryListVM> result = new Paginate<ProductCategoryListVM>(mapDatas, page, count);

            return View(result);
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryCreateVM category)
        {
            if (!ModelState.IsValid) return View();

            if (!category.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!category.Photo.CheckFileSize(200000))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName;

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath,
                "assets/img/ProductCategory",
                fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await category.Photo.CopyToAsync(stream);
            }

            ProductCategory newCategory = new ProductCategory
            {
                Name = category.Name,
                Image = fileName,
            };

            await _context.ProductCategories.AddAsync(newCategory);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                ProductCategory category = await _context.ProductCategories.FirstOrDefaultAsync(m => m.Id == id);

                if (category is null) return NotFound();

                return View(new ProductCategoryUpdateVM
                {
                    Name = category.Name,
                    Photo = category.Photo,
                });

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductCategoryUpdateVM category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                ProductCategory dbCategory = await GetByIdAsync(id);
                if (category.Photo != null)
                {
                    if (!category.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!category.Photo.CheckFileSize(20000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }
                    string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName;
                    ProductCategory categoryDb = await _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    if (categoryDb is null) return NotFound();

                    if (categoryDb.Photo == category.Photo)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/ProductCategory", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await category.Photo.CopyToAsync(stream);
                    }

                    dbCategory.Image = fileName;

                }

                dbCategory.Name = category.Name;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            ProductCategory category = await GetByIdAsync(id);

            if (category == null) return NotFound();

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", category.Image);


            Helper.Helpers.DeleteFile(path);

            _context.ProductCategories.Remove(category);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Services
        private async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        private List<ProductCategoryListVM> GetMapDatas(List<ProductCategory> categories)
        {
            List<ProductCategoryListVM> productCategoryListVMs = new List<ProductCategoryListVM>();

            foreach (var item in categories)
            {
                ProductCategoryListVM newCategories = new ProductCategoryListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image
                };

                productCategoryListVMs.Add(newCategories);
            }

            return productCategoryListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.ProductCategories.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }

        #endregion
    }
}
