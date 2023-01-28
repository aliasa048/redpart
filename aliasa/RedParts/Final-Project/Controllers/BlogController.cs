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
    public class BlogController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public BlogController(AppDbContext context, LayoutService layoutService)

        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int? catId ,int page = 1, int take = 6)
        {
            if (catId is null)
            {
                List<Blog> blogs = await _context.Blogs
                  .Where(m => !m.IsDeleted)
                  .Skip((page * take) - take)
                  .Take(take)
                  .ToListAsync();
                IEnumerable<Blog> recentPosts = await _context.Blogs
                    .Where(m => !m.IsDeleted)
                    .OrderByDescending(m => m.Id)
                    .Take(3)
                    .ToListAsync();
                IEnumerable<BlogCategory> categories = await _context.BlogCategories
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();
                IEnumerable<Tag> tags = await _context.Tags
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();


                ViewBag.take = take;


                List<BlogVM> blogVMs = new List<BlogVM>();

                BlogVM model = new BlogVM
                {
                    Blogs = blogs.ToList(),
                    RecentPost = recentPosts,
                    Categories = categories,
                    Tags = tags
                };

                blogVMs.Add(model);

                int count = await GetPageCount(take);

                Paginate<BlogVM> result = new Paginate<BlogVM>(blogVMs, page, count);

                return View(result);
            }
            else
            {
                List<Blog> blogs = await _context.Blogs
                    .Where(m => !m.IsDeleted && m.BlogCategoryId == catId)
                    .Skip((page * take) - take)
                    .Take(take)
                    .ToListAsync();
                IEnumerable<Blog> recentPosts = await _context.Blogs
                    .Where(m => !m.IsDeleted)
                    .OrderByDescending(m => m.Id)
                    .Take(3)
                    .ToListAsync();
                IEnumerable<BlogCategory> categories = await _context.BlogCategories
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();
                IEnumerable<Tag> tags = await _context.Tags
                    .Where(m => !m.IsDeleted)
                    .ToListAsync();


                ViewBag.take = take;


                List<BlogVM> blogVMs = new List<BlogVM>();

                BlogVM model = new BlogVM
                {
                    Blogs = blogs.ToList(),
                    RecentPost = blogs,
                    Categories = categories,
                    Tags = tags
                };

                blogVMs.Add(model);

                int count = await GetPageCount(take);

                Paginate<BlogVM> result = new Paginate<BlogVM>(blogVMs, page, count);

                return View(result);
            }
        }
        #endregion

        #region Services
        public async Task<int> GetPageCount(int take)
        {
            int blogCount = await _context.Blogs.Where(m => !m.IsDeleted).CountAsync();
            return (int)Math.Ceiling((decimal)blogCount / take);
        }
        #endregion

    }
}
