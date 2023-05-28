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


public class ProductRepository : IProductRepository
{
    private readonly FarmCentralApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductRepository(FarmCentralApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProductDto> CreateAsync(ProductDto entity)
    {
        Product product = _mapper.Map<Product>(entity);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ProductDto> DeleteAsync(ProductDto entity)
    {
        Product product = _mapper.Map<Product>(entity);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<ProductDto>> GetAsync()
    {
        List<ProductDto> products = _mapper
            .Map<List<ProductDto>>
            (await _context.Products.ToListAsync());

        return products;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        ProductDto product = _mapper
            .Map<ProductDto>
            (await _context.Products.FindAsync(id));
        return product;
    }

    public async Task<ProductDto> UpdateAsync(ProductDto entity)
    {
        Product product = _mapper.Map<Product>(await GetByIdAsync(entity.ProductId));
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return entity;
    }
}
