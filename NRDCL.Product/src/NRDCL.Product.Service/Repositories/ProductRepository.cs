using System.Collections.Generic;
using NRDCL.Product.Service.Entities;
using NRDCL.Product.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NRDCL.Product.Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductEntity>> GetAsync()
        {
            return await _context.Product_tbl.ToListAsync();
        }

        public async Task<ProductEntity> GetByIDAsync(int id)
        {
            return await _context.Product_tbl.FirstOrDefaultAsync(m => m.ProductID == id);
        }

        public async Task<bool> CreateAsync(ProductEntity product)
        {
            if (!IsIDExistsAsync(product.ProductID).Result)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ProductEntity product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(ProductEntity product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsIDExistsAsync(int id)
        {
            return await _context.Product_tbl.AnyAsync(e => e.ProductID == id);
        }
    }
}
