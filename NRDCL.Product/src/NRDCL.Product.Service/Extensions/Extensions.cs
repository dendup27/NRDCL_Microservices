using NRDCL.Product.Service.Dtos;
using NRDCL.Product.Service.Entities;

namespace NRDCL.Product.Service.Extensions
{
    public static class Extensions
    {
        public static ProductDto AsDto(this ProductEntity product)
        {
            return new ProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                Rate = product.Rate
            };
        }
    }
}