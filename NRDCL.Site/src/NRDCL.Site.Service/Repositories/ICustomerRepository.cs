using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerEntity>> GetAsync();
        Task<CustomerEntity> GetByIDAsync(string id);
        Task<bool> CreateAsync(CustomerEntity entity);
        Task<bool> UpdateAsync(CustomerEntity entity);
        Task<bool> DeleteAsync(CustomerEntity entity);
    }
}
