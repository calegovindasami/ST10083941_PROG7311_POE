using AutoMapper;
using FarmCentral.Library.Application.Models;
using FarmCentral.Library.Shared.Contracts.Repository;
using FarmCentral.Library.Shared.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Application.Repository;

public class OutgoingTransactionRepository : IOutgoingTransactionRepository
{

    private readonly FarmCentralApplicationDbContext _context;
    private readonly IMapper _mapper;
    public OutgoingTransactionRepository(FarmCentralApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<OutgoingTransactionDto> CreateAsync(OutgoingTransactionDto entity)
    {
        OutgoingTransaction outgoingTransaction = _mapper.Map<OutgoingTransaction>(entity);
        _context.OutgoingTransactions.Add(outgoingTransaction);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<OutgoingTransactionDto> DeleteAsync(OutgoingTransactionDto entity)
    {
        OutgoingTransaction outgoingTransaction = _mapper.Map<OutgoingTransaction>(entity);
        _context.OutgoingTransactions.Remove(outgoingTransaction);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<OutgoingTransactionDto>> GetAsync()
    {
        List<OutgoingTransactionDto> outgoingTransactions = _mapper
            .Map<List<OutgoingTransactionDto>>
            (await _context.OutgoingTransactions.ToListAsync());
        return outgoingTransactions;
    }

    public async Task<OutgoingTransactionDto> GetByIdAsync(int id)
    {
        OutgoingTransactionDto outgoingTransaction = _mapper.Map<OutgoingTransactionDto>(await _context.OutgoingTransactions.FindAsync(id));
        return outgoingTransaction;
    }

    public async Task<OutgoingTransactionDto> UpdateAsync(OutgoingTransactionDto entity)
    {
        OutgoingTransaction outgoingTransaction = _mapper.Map<OutgoingTransaction>(await GetByIdAsync(entity.OutgoingTransactionId));
        _context.OutgoingTransactions.Update(outgoingTransaction);
        await _context.SaveChangesAsync();
        return entity;
    }
}
