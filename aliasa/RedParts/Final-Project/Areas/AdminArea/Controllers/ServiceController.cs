using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Service;
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
    public class ServiceController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Service> services = await _context.Services
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<ServiceListVM> mapDatas = GetMapDatas(services);

            int count = await GetPageCount(take);

            Paginate<ServiceListVM> result = new Paginate<ServiceListVM>(mapDatas, page, count);

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

                Service service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

                if (service is null) return NotFound();

                return View(new ServiceEditVM
                {
                    Title = service.Title,
                    Description = service.Description,
                    Icon = service.Icon
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
        public async Task<IActionResult> Update(int id, ServiceEditVM service)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }
                Service dbService = await GetByIdAsync(id);

                dbService.Icon = service.Icon;
                dbService.Title = service.Title;
                dbService.Description = service.Description;

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
        public async Task<IActionResult> Create(ServiceCreateVM service)
        {
            if (!ModelState.IsValid) return View();


            Service newService = new Service
            {
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon,
            };

            await _context.Services.AddAsync(newService);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Service services = await GetByIdAsync(id);

            if (services == null) return NotFound();

            _context.Services.Remove(services);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Services
        private async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        private List<ServiceListVM> GetMapDatas(List<Service> services)
        {
            List<ServiceListVM> serviceListVMs = new List<ServiceListVM>();

            foreach (var item in services)
            {
                ServiceListVM newService = new ServiceListVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Icon = item.Icon,
                };

                serviceListVMs.Add(newService);
            }

            return serviceListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int serviceCount = await _context.Services.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)serviceCount / take);
        }

        #endregion
    }
}
