using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Country;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CountryController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public CountryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Country> countries = await _context.Countries
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<CountryListVM> mapDatas = GetMapDatas(countries);

            int count = await GetPageCount(take);

            Paginate<CountryListVM> result = new Paginate<CountryListVM>(mapDatas, page, count);

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
        public async Task<IActionResult> Create(CountryCreateVM country)
        {
            if (!ModelState.IsValid) return View();


            Country newCountry = new Country
            {
                Name = country.Name,
            };

            await _context.Countries.AddAsync(newCountry);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            country.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Country country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

                if (country is null) return NotFound();

                return View(new CountryEditVM
                {
                    Name = country.Name,
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
        public async Task<IActionResult> Edit(int id, CountryEditVM country)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(country);
                }
                Country dbCountry = await GetByIdAsync(id);


                dbCountry.Name = country.Name;

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
        private async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        private List<CountryListVM> GetMapDatas(List<Country> countries)
        {
            List<CountryListVM> countryListVMs = new List<CountryListVM>();

            foreach (var item in countries)
            {
                CountryListVM newCountry = new CountryListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                countryListVMs.Add(newCountry);
            }

            return countryListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int countryCount = await _context.Countries.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)countryCount / take);
        }

        #endregion
    }
}
