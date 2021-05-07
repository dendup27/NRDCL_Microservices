using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Product.Service.Entities;

namespace NRDCL.Product.Service.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAsync();
        Task<ProductEntity> GetByIDAsync(int id);
        Task<bool> CreateAsync(ProductEntity entity);
        Task<bool> UpdateAsync(ProductEntity entity);
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<bool> IsIDExistsAsync(int id);
    }
}
