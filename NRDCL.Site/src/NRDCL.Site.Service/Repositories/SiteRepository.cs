using System.Collections.Generic;
using NRDCL.Site.Service.Entities;
using NRDCL.Site.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NRDCL.Site.Service.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly SiteDbContext _context;

        public SiteRepository(SiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<SiteEntity>> GetAsync()
        {
            return await _context.Site_tbl.ToListAsync();
        }

        public async Task<SiteEntity> GetByIDAsync(int id)
        {
            return await _context.Site_tbl.FirstOrDefaultAsync(m => m.SiteID == id);
        }

        public async Task<bool> CreateAsync(SiteEntity siteEntity)
        {
            if (!IsIDExistsAsync(siteEntity.SiteID).Result)
            {
                _context.Add(siteEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(SiteEntity siteEntity)
        {
            _context.Update(siteEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(SiteEntity siteEntity)
        {
            _context.Remove(siteEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsIDExistsAsync(int id)
        {
            return await _context.Site_tbl.AnyAsync(e => e.SiteID == id);
        }
    }
}
