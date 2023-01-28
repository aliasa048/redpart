using Final_Project.Data;
using Final_Project.Helper;
using Final_Project.Models;
using Final_Project.ViewModels.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImage)
                .Include(m => m.Brand)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<ProductListVM> mapDatas = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductListVM> result = new Paginate<ProductListVM>(mapDatas, page, count);

            return View(result);
        }
        #endregion

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.brands = await GetBrandAsync();
            ViewBag.countries = await GetCountryAsync();
            var data = await GetMaterialsAsync();

            ProductCreateVM productCreateVM = new ProductCreateVM()
            {
                Materials = data
            };


            return View(productCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM product)
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.countries = await GetCountryAsync();
            ViewBag.brands = await GetBrandAsync();

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            foreach (var photo in product.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View(product);
                }


                if (!photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image size");
                    return View(product);
                }

            }

            List<ProductImage> images = new List<ProductImage>();

            foreach (var photo in product.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/Product", fileName);

                await Helper.Helpers.SaveFile(path, photo);


                ProductImage image = new ProductImage
                {
                    Image = fileName,
                };

                images.Add(image);
            }

            images.FirstOrDefault().IsMain = true;

            decimal convertedPrice = decimal.Parse(product.Price.Replace(".", ","));

            Product newProduct = new Product
            {
                Name = product.Title,
                Description = product.Description,
                Price = (int)convertedPrice,
                StockCount = product.StockCount,
                ProductCategoryId = product.CategoryId,
                ProductImage = images,
                BrandId = product.BrandId,
                CountryId = product.CountryId,
                SKU = product.SKU
            };

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();

            // Product dbProduct = await _context.Products.FirstOrDefaultAsync(m => m.Id == 1);

            foreach (var item in product.Materials.Where(m => m.IsSelected))
            {
                ProductMaterial productMaterial = new ProductMaterial
                {
                    ProductId = newProduct.Id,
                    MaterialId = item.Id,
                };
                await _context.ProductMaterials.AddAsync(productMaterial);
            }

            _context.ProductImage.UpdateRange(images);
            _context.Products.Update(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductImage)
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();

            foreach (var item in product.ProductImage)
            {
                string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", item.Image);
                Helper.Helpers.DeleteFile(path);
                item.IsDeleted = true;
            }

            product.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private decimal StringToDecimal(string str)
        {
            return decimal.Parse(str.Replace(".", ","));
        }
        #endregion

        #region Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
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
                .FirstOrDefaultAsync();

            List<ProductMaterial> productMaterials = await _context.ProductMaterials.Where(m => m.ProductId == id).ToListAsync();
            List<Material> materials = new List<Material>();
            foreach (var size in productMaterials)
            {
                Material dbMaterial = await _context.Material.Where(m => m.Id == size.MaterialId).FirstOrDefaultAsync();
                materials.Add(dbMaterial);
            }

            if (product == null)
            {
                return NotFound();
            }
            var data = await GetMaterialsAsync();

            ProductDetailVM productDetail = new ProductDetailVM
            {
                Title = product.Name,
                Price = product.Price,
                Description = product.Description,
                Images = product.ProductImage,
                StockCount = product.StockCount,
                Category = product.ProductCategory.Name,
                Brand = product.Brand.Name,
                Materials = materials,
                SellingCount = product.SellingCount,
                SKU = product.SKU
            };




            return View(productDetail);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            ViewBag.brands = await GetBrandAsync();
            ViewBag.countries = await GetCountryAsync();
            ViewBag.categories = await GetCategoriesAsync();

            Product dbProduct = await GetByIdAsync((int)id);

            return View(new ProductEditVM
            {
                Title = dbProduct.Name,
                Description = dbProduct.Description,
                Price = dbProduct.Price.ToString("0.#####").Replace(",", "."),
                CategoryId = dbProduct.ProductCategoryId,
                Images = dbProduct.ProductImage,
                Stock_Count = dbProduct.StockCount,
                BrandId = dbProduct.BrandId,
                CountryId = dbProduct.CountryId

            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditVM updatedProduct)
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.brands = await GetBrandAsync();

            if (!ModelState.IsValid) return View(updatedProduct);

            Product dbProduct = await GetByIdAsync(id);

            if (updatedProduct.Photos != null)
            {

                foreach (var photo in updatedProduct.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(updatedProduct);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View(updatedProduct);
                    }

                }

                foreach (var item in dbProduct.ProductImage)
                {
                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "img", item.Image);
                    Helper.Helpers.DeleteFile(path);
                }


                List<ProductImage> images = new List<ProductImage>();

                foreach (var photo in updatedProduct.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.Helpers.GetFilePath(_env.WebRootPath, "assets/img/product", fileName);

                    await Helper.Helpers.SaveFile(path, photo);


                    ProductImage image = new ProductImage
                    {
                        Image = fileName,
                    };

                    images.Add(image);

                }

                images.FirstOrDefault().IsMain = true;

                dbProduct.ProductImage = images;

            }

            decimal convertedPrice = StringToDecimal(updatedProduct.Price);



            dbProduct.Name = updatedProduct.Title;
            dbProduct.Description = updatedProduct.Description;
            dbProduct.Price = (int)convertedPrice;
            dbProduct.ProductCategoryId = updatedProduct.CategoryId;
            dbProduct.StockCount = updatedProduct.Stock_Count;
            dbProduct.BrandId = updatedProduct.BrandId;
            dbProduct.CountryId = updatedProduct.CountryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Services
        private async Task<SelectList> GetCategoriesAsync()
        {
            IEnumerable<ProductCategory> categories = await _context.ProductCategories.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
        private async Task<SelectList> GetBrandAsync()
        {
            IEnumerable<Brand> brands = await _context.Brands.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(brands, "Id", "Name");
        }
        private async Task<SelectList> GetCountryAsync()
        {
            IEnumerable<Country> countries = await _context.Countries.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(countries, "Id", "Name");
        }
        private async Task<List<Material>> GetMaterialsAsync()
        {
            List<Material> materials = await _context.Material.Where(m => !m.IsDeleted).ToListAsync();
            return materials;
        }

        private async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductCategory)
                .Include(m => m.ProductImage)
                .FirstOrDefaultAsync();
        }

        private List<ProductListVM> GetMapDatas(List<Product> products)
        {
            List<ProductListVM> productList = new List<ProductListVM>();

            foreach (var product in products)
            {
                ProductListVM newProduct = new ProductListVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    MainImage = product.ProductImage.Where(m => m.IsMain).FirstOrDefault()?.Image,
                    Brand = product.Brand.Name,
                    Price = product.Price
                };

                productList.Add(newProduct);
            }

            return productList;
        }

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
        #endregion
    }
}
