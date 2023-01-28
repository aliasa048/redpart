using Final_Project.Data;
using Final_Project.Models;
using Final_Project.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class ShopDetailController : Controller
    {
        #region readonly
        private readonly AppDbContext _context;
        #endregion

        #region Constructor
        public ShopDetailController(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .Include(m => m.ProductCategory)
                .Include(m => m.Brand)
                .Include(m => m.Country)
                .Include(m => m.ProductMaterials)
                .FirstOrDefaultAsync();
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Where(m => m.ProductCategoryId == product.ProductCategoryId)
                .Take(4)
                .OrderByDescending(m => m.Id)
                .Include(m => m.ProductImage)
                .ToListAsync();

            if (product == null)
            {
                return NotFound();
            }

            List<ProductMaterial> productMaterials = await _context.ProductMaterials.Where(m => m.ProductId == id).ToListAsync();
            List<Material> materials = new List<Material>();
            foreach (var material in productMaterials)
            {
                Material dbMaterial = await _context.Material.Where(m => m.Id == material.MaterialId).FirstOrDefaultAsync();
                materials.Add(dbMaterial);
            }

            ShopDetailVM productDetailVM = new ShopDetailVM
            {
                Id = product.Id,
                Title = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = product.ProductCategory.Name,
                ProductImages = product.ProductImage,
                FeaturedProducts = products,
                MainImage = product.ProductImage.FirstOrDefault(m => m.IsMain)?.Image,
                Materials = materials,
                SKU = product.SKU,
                Brand = product.Brand.Name,
                Country = product.Country.Name,
                CatId = product.ProductCategoryId
                
            };

            return View(productDetailVM);
        }
        #endregion
    }
}
