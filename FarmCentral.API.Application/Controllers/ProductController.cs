using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }

        [HttpPost("post")]
        public async Task<ProductDto> Post(ProductDto product)
        {
            return await repository.CreateAsync(product);
        }
        [HttpDelete("delete")]
        public async Task<ProductDto> Delete(ProductDto product)
        {
            return await repository.DeleteAsync(product);
        }

        [HttpGet("get")]
        public async Task<List<ProductDto>> Get()
        {
            return await repository.GetAsync();
        }

        [HttpGet("getbyid")]
        public async Task<ProductDto> GetById(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
