using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Repositories
{
    public interface ISiteRepository
    {
        Task<List<SiteEntity>> GetAsync();
        Task<SiteEntity> GetByIDAsync(int id);
        Task<bool> CreateAsync(SiteEntity entity);
        Task<bool> UpdateAsync(SiteEntity entity);
        Task<bool> DeleteAsync(SiteEntity entity);
        Task<bool> IsIDExistsAsync(int id);
    }
}
