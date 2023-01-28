using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Employee;
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
    [Area("Adminarea")]
    public class EmployeeController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public EmployeeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Employee> employees = await _context.Employees
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<EmployeeListVM> mapDatas = GetMapDatas(employees);

            int count = await GetPageCount(take);

            Paginate<EmployeeListVM> result = new Paginate<EmployeeListVM>(mapDatas, page, count);

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

                Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

                if (employee is null) return NotFound();

                return View(new EmployeeEditVM
                {
                    FullName = employee.FulLName,
                    Position = employee.Position,
                    Image = employee.Image,
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
        public async Task<IActionResult> Update(int id, EmployeeEditVM employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                Employee dbEmployee = await GetByIdAsync(id);
                if (employee.Photo != null)
                {
                    if (!employee.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!employee.Photo.CheckFileSize(20000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }
                    string fileName = Guid.NewGuid().ToString() + "_" + employee.Photo.FileName;
                    Employee employeeDb = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    if (employeeDb is null) return NotFound();

                    if (employeeDb.Image == employee.Image)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Employee", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await employee.Photo.CopyToAsync(stream);
                    }

                    dbEmployee.Image = fileName;

                }

                dbEmployee.FulLName = employee.FullName;
                dbEmployee.Position = employee.Position;

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
        public async Task<IActionResult> Create(EmployeeCreateVM employee)
        {
            if (!ModelState.IsValid) return View();

            if (!employee.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!employee.Photo.CheckFileSize(200000))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + employee.Photo.FileName;

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Employee", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await employee.Photo.CopyToAsync(stream);
            }

            Employee newEmployee = new Employee
            {
                FulLName = employee.FullName,
                Position = employee.Position,
                Image = fileName,
            };

            await _context.Employees.AddAsync(newEmployee);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await GetByIdAsync(id);

            if (employee == null) return NotFound();

            string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", employee.Image);


            Helper.Helpers.DeleteFile(path);

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Services
        private async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        private List<EmployeeListVM> GetMapDatas(List<Employee> employees)
        {
            List<EmployeeListVM> employeeListVMs = new List<EmployeeListVM>();

            foreach (var item in employees)
            {
                EmployeeListVM newEmployee = new EmployeeListVM
                {
                    Id = item.Id,
                    FullName = item.FulLName,
                    Position = item.Position,
                    Image = item.Image
                };

                employeeListVMs.Add(newEmployee);
            }

            return employeeListVMs;
        }

        private async Task<int> GetPageCount(int take)
        {
            int employeeCount = await _context.Employees.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)employeeCount / take);
        }

        #endregion
    }
}
