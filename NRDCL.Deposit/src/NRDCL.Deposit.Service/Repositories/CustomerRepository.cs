using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NRDCL.Deposit.Service.DBContexts;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DepositDbContext _context;

        public CustomerRepository(DepositDbContext context)
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
