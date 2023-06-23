using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductTypeController : Controller
{
    private readonly IProductTypeRepository _repository;

    public ProductTypeController(IProductTypeRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("post")]
    public async Task<ProductTypeDto> Post(ProductTypeDto model)
    {
        return await _repository.CreateAsync(model);
    }

    [HttpDelete("delete")]
    public async Task<ProductTypeDto> Delete(ProductTypeDto model)
    {
        return await _repository.DeleteAsync(model);
    }

    [HttpGet("get")]
    public async Task<List<ProductTypeDto>> Get()
    {
        return await _repository.GetAsync();
    }

    [HttpGet("getbyid")]
    public async Task<ProductTypeDto> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

}
