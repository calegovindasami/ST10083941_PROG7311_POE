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
//Concrete implementation for the farmer repository.
public class FarmerRepository : IFarmerRepository
{
    private readonly FarmCentralApplicationDbContext _context;
    private readonly IMapper _mapper;
    public FarmerRepository(FarmCentralApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<FarmerDto> CreateAsync(FarmerDto entity)
    {
        Farmer farmer = _mapper.Map<Farmer>(entity);
        _context.Farmers.Add(farmer);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<FarmerDto> DeleteAsync(FarmerDto entity)
    {
        Farmer farmer = _mapper.Map<Farmer>(entity);
        _context.Farmers.Remove(farmer);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<FarmerDto>> GetAsync()
    {
        List<FarmerDto> farmers = _mapper
            .Map<List<FarmerDto>>
            (await _context.Farmers.ToListAsync());

        return farmers;
    }

    public async Task<FarmerDto> GetByIdAsync(string id)
    {
        FarmerDto farmer = _mapper
            .Map<FarmerDto>
            (await _context.Farmers.FindAsync(id));
        return farmer;
    }

    public async Task<FarmerDto> UpdateAsync(FarmerDto entity)
    {
        Farmer farmer = _mapper.Map<Farmer>(await GetByIdAsync(entity.FarmerId));
        _context.Farmers.Update(farmer);
        await _context.SaveChangesAsync();
        return entity;
    }
}
