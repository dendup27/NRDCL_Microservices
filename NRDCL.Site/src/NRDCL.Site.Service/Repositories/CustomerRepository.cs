using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NRDCL.Site.Service.DBContexts;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SiteDbContext _context;

        public CustomerRepository(SiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntity>> GetAsync()
        {
            return await _context.Customer_tbl.ToListAsync();
        }

        public async Task<CustomerEntity> GetByIDAsync(string id)
        {
            return await _context.Customer_tbl.FirstOrDefaultAsync(m => m.CustomerCID == id);
        }

        public async Task<bool> CreateAsync(CustomerEntity customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return true;

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
    }
}
