using FarmCentral.Library.Application.Models;
using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmerController : Controller
{
    private readonly IFarmerRepository _repository;
    public FarmerController(IFarmerRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost("post")]
    public async Task<FarmerDto> Post(FarmerDto farmer)
    {
        return await _repository.CreateAsync(farmer);
    }

    [HttpDelete("delete")]
    public async Task<FarmerDto> Delete(FarmerDto farmer)
    {
        return await _repository.DeleteAsync(farmer);
    }

    [HttpGet("get")]
    public async Task<List<FarmerDto>> Get()
    {
        return await _repository.GetAsync();
    }

    [HttpGet("getbyid")]
    public async Task<FarmerDto> GetById(string id)
    {
        return await _repository.GetByIdAsync(id);
    }


}
