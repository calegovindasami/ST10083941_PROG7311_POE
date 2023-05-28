using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FarmerProductController : ControllerBase
{
    private readonly IFarmerProductRepository _repository;

    public FarmerProductController(IFarmerProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("post")] 
    public async Task<FarmerProductDto> Post(FarmerProductDto farmerProduct)
    {
        return await _repository.CreateAsync(farmerProduct);
    }

    [HttpDelete("delete")]
    public async Task<FarmerProductDto> Delete(FarmerProductDto farmerProduct)
    {
        return await _repository.DeleteAsync(farmerProduct);
    }

    [HttpGet("get")]
    public async Task<List<FarmerProductDto>> Get()
    {
        return await _repository.GetAsync();
    }

    [HttpGet("getbyid")]
    public async Task<FarmerProductDto> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
