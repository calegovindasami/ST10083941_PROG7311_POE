using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.API.Application.Controllers;

[ApiController]
[Route("[controller]")]

public class OutgoingTransactionController : ControllerBase
{
    private readonly IOutgoingTransactionRepository _repository;
    public OutgoingTransactionController(IOutgoingTransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("post")]
    public async Task<OutgoingTransactionDto> Post(OutgoingTransactionDto outgoingTransaction)
    {
        return await _repository.CreateAsync(outgoingTransaction);
    }

    [HttpDelete("delete")]
    public async Task<OutgoingTransactionDto> Delete(OutgoingTransactionDto outgoingTransaction)
    {
        return await _repository.DeleteAsync(outgoingTransaction);
    }

    [HttpGet("get")]
    public async Task<List<OutgoingTransactionDto>> Get()
    {
        return await _repository.GetAsync();
    }

    [HttpGet("getbyid")]
    public async Task<OutgoingTransactionDto> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
