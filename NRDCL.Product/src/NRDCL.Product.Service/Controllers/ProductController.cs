using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Product.Service.Dtos;
using NRDCL.Product.Service.Extensions;
using NRDCL.Product.Service.Entities;
using MassTransit;
using NRDCL.Product.Service.Repositories;
using NRDCL.Common.Dtos.Product;

namespace NRDCL.Product.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductController(IProductRepository productRepository, IPublishEndpoint publishEndpoint)
        {
            _productRepository = productRepository;
            _publishEndpoint = publishEndpoint;
        }

        //GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync()
        {
            return Ok((await _productRepository.GetAsync()).Select(item => item.AsDto()));
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIDAsync(int id)
        {
            var product = await _productRepository.GetByIDAsync(id);
            return product != null ? product.AsDto() : NotFound();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(CreateProductDto createProductDto)
        {
            var product = new ProductEntity
            {
                ProductID = createProductDto.ProductID,
                ProductName = createProductDto.ProductName,
                Price = createProductDto.Price,
                Rate = createProductDto.Rate
            };

            await _productRepository.CreateAsync(product);
            await _publishEndpoint.Publish(new ProductCreated(
                product.ProductID, product.ProductName, product.Price, product.Rate
            ));
            return CreatedAtAction(nameof(GetByIDAsync), new { id = product.ProductID }, product);
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIDAsync(id);

            if (product == null)
                return NotFound();

            product.ProductName = updateProductDto.ProductName;
            product.Price = updateProductDto.Price;
            product.Rate = updateProductDto.Rate;

            await _productRepository.UpdateAsync(product);
            await _publishEndpoint.Publish(new ProductUpdated(
                product.ProductID, product.ProductName, product.Price, product.Rate
            ));
            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIDAsync(id);

            if (product == null)
                return NotFound();

            await _productRepository.DeleteAsync(product);
            await _publishEndpoint.Publish(new ProductDeleted(product.ProductID));
            return NoContent();
        }
    }
}
