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

namespace FarmCentral.Library.Application.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly FarmCentralApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductTypeRepository(IMapper mapper, FarmCentralApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductTypeDto> CreateAsync(ProductTypeDto entity)
        {
            ProductType productType = _mapper.Map<ProductType>(entity);
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductTypeDto> DeleteAsync(ProductTypeDto entity)
        {
            ProductType productType = _mapper.Map<ProductType>(entity);
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ProductTypeDto>> GetAsync()
        {
            List<ProductTypeDto> productTypes = _mapper
            .Map<List<ProductTypeDto>>
            (await _context.ProductTypes.ToListAsync());

            return productTypes;
        }

        public async Task<ProductTypeDto> GetByIdAsync(int id)
        {
            ProductTypeDto productType = _mapper
            .Map<ProductTypeDto>
            (await _context.ProductTypes.FindAsync(id));
            return productType;
        }

        public async Task<ProductTypeDto> UpdateAsync(ProductTypeDto entity)
        {
            ProductType productType = _mapper.Map<ProductType>(await GetByIdAsync(entity.ProductTypeId));
            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
