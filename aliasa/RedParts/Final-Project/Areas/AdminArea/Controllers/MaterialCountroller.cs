using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Material;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("Adminarea")]
    public class MaterialController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public MaterialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Material> materials = await _context.Material
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<MaterialListVM> mapDatas = GetMapDatas(materials);

            int count = await GetPageCount(take);

            Paginate<MaterialListVM> result = new Paginate<MaterialListVM>(mapDatas, page, count);

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
        public async Task<IActionResult> Create(MaterialListVM material)
        {
            if (!ModelState.IsValid) return View();


            Material newMaterial = new Material
            {
                Name = material.Name,
            };

            await _context.Material.AddAsync(newMaterial);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Material material = await _context.Material.FirstOrDefaultAsync(m => m.Id == id);

            material.IsDeleted = true;

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

                Material material = await _context.Material.FirstOrDefaultAsync(m => m.Id == id);

                if (material is null) return NotFound();

                return View(new MaterialEditVM
                {
                    Name = material.Name,

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
        public async Task<IActionResult> Update(int id, MaterialEditVM material)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(material);
                }
                Material dbMaterial = await GetByIdAsync(id);


                dbMaterial.Name = material.Name;

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

        #region Services
        private async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Material.FindAsync(id);
        }

        private List<MaterialListVM> GetMapDatas(List<Material> materials)
        {
            List<MaterialListVM> materialListVMs = new List<MaterialListVM>();

            foreach (var item in materials)
            {
                MaterialListVM newMaterial = new MaterialListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                materialListVMs.Add(newMaterial);
            }

            return materialListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int tagCount = await _context.Material.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)tagCount / take);
        }

        #endregion
    }
}
