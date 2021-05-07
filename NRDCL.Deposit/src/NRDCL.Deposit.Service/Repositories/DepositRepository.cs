using System.Collections.Generic;
using NRDCL.Deposit.Service.Entities;
using NRDCL.Deposit.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NRDCL.Deposit.Service.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DepositDbContext _context;

        public DepositRepository(DepositDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepositEntity>> GetAsync()
        {
            return await _context.Deposit_tbl.ToListAsync();
        }

        public async Task<DepositEntity> GetByIDAsync(string id)
        {
            return await _context.Deposit_tbl.FirstOrDefaultAsync(m => m.CustomerCID == id);
        }

        public async Task<bool> CreateAsync(DepositEntity deposit)
        {
            if (!IsIDExistsAsync(deposit.CustomerCID).Result)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(DepositEntity deposit)
        {
            _context.Update(deposit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(DepositEntity deposit)
        {
            _context.Remove(deposit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsIDExistsAsync(string id)
        {
            return await _context.Deposit_tbl.AnyAsync(e => e.CustomerCID == id);
        }
    }
}
