using System.Collections.Generic;
using NRDCL.Order.Service.Entities;
using NRDCL.Order.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NRDCL.Order.Service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderEntity>> GetAsync()
        {
            return await _context.Order_tbl.ToListAsync();
        }

        public async Task<OrderEntity> GetByIDAsync(int id)
        {
            return await _context.Order_tbl.FirstOrDefaultAsync(m => m.OrderID == id);
        }

        public async Task<bool> CreateAsync(OrderEntity order)
        {
            if (!IsIDExistsAsync(order.OrderID).Result)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(OrderEntity order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(OrderEntity order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsIDExistsAsync(int id)
        {
            return await _context.Order_tbl.AnyAsync(e => e.OrderID == id);
        }
    }
}
