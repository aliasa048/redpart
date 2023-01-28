using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Slider;
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
    public class SliderController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Slider> sliders = await _context.Sliders
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<SliderListVM> mapDatas = GetMapDatas(sliders);

            int count = await GetPageCount(take);

            Paginate<SliderListVM> result = new Paginate<SliderListVM>(mapDatas, page, count);

            return View(result);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

                if (slider is null) return NotFound();

                return View(new SliderEditVM
                {
                    Title = slider.Title,
                    Header = slider.Header,
                    Description = slider.Description,
                    Image = slider.Image,
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
        public async Task<IActionResult> Update(int id, SliderEditVM slider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(slider);
                }
                Slider dbSlider = await GetByIdAsync(id);
                if (slider.Photo != null)
                {
                    if (!slider.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!slider.Photo.CheckFileSize(20000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }
                    string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
                    Slider sliderDb = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    if (sliderDb is null) return NotFound();

                    if (sliderDb.Image == slider.Image)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Slider", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await slider.Photo.CopyToAsync(stream);
                    }

                    dbSlider.Image = fileName;

                }

                dbSlider.Title = slider.Title;
                dbSlider.Header = slider.Header;
                dbSlider.Description = slider.Description;

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

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM slider)
        {
            if (!ModelState.IsValid) return View();

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!slider.Photo.CheckFileSize(200000))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Slider", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }

            Slider newSlider = new Slider
            {
                Title = slider.Title,
                Header = slider.Header,
                Description = slider.Description,
                Image = fileName,
            };

            await _context.Sliders.AddAsync(newSlider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await GetByIdAsync(id);

            if (slider == null) return NotFound();

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", slider.Image);


            Helper.Helpers.DeleteFile(path);

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion



        #region Services
        private async Task<Slider> GetByIdAsync(int id)
        {
            return await _context.Sliders.FindAsync(id);
        }

        private List<SliderListVM> GetMapDatas(List<Slider> sliders)
        {
            List<SliderListVM> sliderListVMs = new List<SliderListVM>();

            foreach (var item in sliders)
            {
                SliderListVM slider = new SliderListVM
                {
                    Id = item.Id,
                    Description = item.Description,
                    Title = item.Title,
                    Header = item.Header,
                    Image = item.Image
                };

                sliderListVMs.Add(slider);
            }

            return sliderListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int sliderCount = await _context.Sliders.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)sliderCount / take);
        }
        #endregion
    }
}
