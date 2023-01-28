using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Final_Project.ViewCompanents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HeaderViewComponent(LayoutService layoutService, AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _layoutService = layoutService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;


        }
        public async Task<int> GetUserBasketProductsCount(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            if (user == null) return 0;
            var basketProductCount = await _context.BasketProducts.Where(bp => bp.Basket.AppUserId == user.Id).SumAsync(bp => bp.Quantity);
            return basketProductCount;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();

            HeaderVM headerVM = new HeaderVM
            {
                Settings = setting,
                Count = await GetUserBasketProductsCount(_httpContextAccessor.HttpContext.User),

            };

            return await Task.FromResult(View(headerVM));
        }
    }
}
