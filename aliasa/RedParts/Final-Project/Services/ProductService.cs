using Final_Project.Data;
using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll(int take)
        {
            return await _context.Products.Where(m => !m.IsDeleted).Include(m => m.ProductImage).Take(take).OrderBy(m => m.Id).ToListAsync();
        }
    }
}
