using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Order.Service.Entities;

namespace NRDCL.Order.Service.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAsync();
        Task<OrderEntity> GetByIDAsync(int id);
        Task<bool> CreateAsync(OrderEntity entity);
        Task<bool> UpdateAsync(OrderEntity entity);
        Task<bool> DeleteAsync(OrderEntity entity);
        Task<bool> IsIDExistsAsync(int id);
    }
}
