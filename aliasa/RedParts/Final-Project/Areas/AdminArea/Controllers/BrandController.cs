

using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Brand;
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
    public class BrandController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Brand> brands = await _context.Brands
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<BrandListVM> mapDatas = GetMapDatas(brands);

            int count = await GetPageCount(take);

            Paginate<BrandListVM> result = new Paginate<BrandListVM>(mapDatas, page, count);

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
        public async Task<IActionResult> Create(BrandCreateVM brand)
        {
            if (!ModelState.IsValid) return View();

            if (!brand.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!brand.Photo.CheckFileSize(200000))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath,
                "assets/img/Brand",
                fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await brand.Photo.CopyToAsync(stream);
            }

            Brand newBrand = new Brand
            {
                Name = brand.Name,
                Image = fileName,
            };

            await _context.Brands.AddAsync(newBrand);

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

                Brand brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

                if (brand is null) return NotFound();

                return View(new BrandUpdateVM
                {
                    Name = brand.Name,
                    Photo = brand.Photo,
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
        public async Task<IActionResult> Update(int id, BrandUpdateVM brand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(brand);
                }
                Brand dbBrand = await GetByIdAsync(id);
                if (brand.Photo != null)
                {
                    if (!brand.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!brand.Photo.CheckFileSize(20000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }
                    string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;
                    Brand brandDb = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    if (brandDb is null) return NotFound();

                    if (brandDb.Photo == brand.Photo)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Brand", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await brand.Photo.CopyToAsync(stream);
                    }

                    dbBrand.Image = fileName;

                }

                dbBrand.Name = brand.Name;

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
            Brand brand = await GetByIdAsync(id);

            if (brand == null) return NotFound();

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", brand.Image);


            Helper.Helpers.DeleteFile(path);

            _context.Brands.Remove(brand);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Services
        private async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        private List<BrandListVM> GetMapDatas(List<Brand> brands)
        {
            List<BrandListVM> brandListVMs = new List<BrandListVM>();

            foreach (var item in brands)
            {
                BrandListVM newBrand = new BrandListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image
                };

                brandListVMs.Add(newBrand);
            }

            return brandListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int brandCount = await _context.Brands.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)brandCount / take);
        }

        #endregion
    }
}
