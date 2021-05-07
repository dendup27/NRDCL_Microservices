using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Repositories
{
    public interface IDepositRepository
    {
        Task<List<DepositEntity>> GetAsync();
        Task<DepositEntity> GetByIDAsync(string id);
        Task<bool> CreateAsync(DepositEntity entity);
        Task<bool> UpdateAsync(DepositEntity entity);
        Task<bool> DeleteAsync(DepositEntity entity);
        Task<bool> IsIDExistsAsync(string id);
    }
}
