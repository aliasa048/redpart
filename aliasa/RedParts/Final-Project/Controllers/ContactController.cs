using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class ContactController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public ContactController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();
            string Address = settingDatas["Address"];
            string PhoneNumber = settingDatas["Num"];
            string Email = settingDatas["Email"];


            ViewBag.Address = Address;
            ViewBag.PhoneNumber = PhoneNumber;
            ViewBag.Email = Email;

            return View();
        }

        #region
        [HttpPost]
        public async Task<IActionResult> ContactUs(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        #endregion
    }
}
