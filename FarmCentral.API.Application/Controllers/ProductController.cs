using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("post")]
        public async Task<ProductDto> Post(ProductDto product)
        {
            return await _productRepository.CreateAsync(product);
        }
        [HttpDelete("delete")]
        public async Task<ProductDto> Delete(ProductDto product)
        {
            return await _productRepository.DeleteAsync(product);
        }

        [HttpGet("get")]
        public async Task<List<ProductDto>> Get()
        {
            return await _productRepository.GetAsync();
        }

        [HttpGet("getbyid")]
        public async Task<ProductDto> GetById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
