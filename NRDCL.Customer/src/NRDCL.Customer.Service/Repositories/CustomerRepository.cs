using System.Collections.Generic;
using NRDCL.Customer.Service.Entities;
using NRDCL.Customer.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NRDCL.Customer.Service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntity>> GetAsync()
        {
            return await _context.CustomerTable.ToListAsync();
        }

        public async Task<CustomerEntity> GetByIDAsync(string id)
        {
            return await _context.CustomerTable.FirstOrDefaultAsync(m => m.CustomerCID == id);
        }

        public async Task<bool> CreateAsync(CustomerEntity customer)
        {
            if (!IsIDExistsAsync(customer.CustomerCID).Result)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(CustomerEntity customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(CustomerEntity customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsIDExistsAsync(string id)
        {
            return await _context.CustomerTable.AnyAsync(e => e.CustomerCID == id);
        }
    }
}
