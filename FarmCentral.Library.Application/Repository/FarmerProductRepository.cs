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
    //Concrete implementation for the farmer product repository.
    public class FarmerProductRepository : IFarmerProductRepository
    {
        private readonly FarmCentralApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FarmerProductRepository(FarmCentralApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FarmerProductDto> CreateAsync(FarmerProductDto entity)
        {
            //Prevents duplicate products from being created within the database.
            FarmerProduct farmerProduct = _mapper.Map<FarmerProduct>(entity);
            var productExists = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == entity.ProductName);

            if (productExists != null)
            {
                farmerProduct.ProductId = productExists.ProductId;
                farmerProduct.Product = productExists;
            }

            var productTypeExists = await _context.ProductTypes.FirstOrDefaultAsync(x => x.ProductTypeName == entity.ProductTypeName);
            if (productTypeExists != null)
            {
                farmerProduct.Product.ProductTypeId = productTypeExists.ProductTypeId;
                farmerProduct.Product.ProductType = productTypeExists;
            }

            _context.FarmerProducts.Add(farmerProduct);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<FarmerProductDto> DeleteAsync(FarmerProductDto entity)
        {
            FarmerProduct farmerProduct = _mapper.Map<FarmerProduct>(entity);
            _context.FarmerProducts.Remove(farmerProduct);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<FarmerProductDto>> GetAsync()
        {
            var f = await _context.FarmerProducts.Include(x => x.Product).ThenInclude(x => x.ProductType).ToListAsync();
            List<FarmerProductDto> farmerProducts = _mapper
            .Map<List<FarmerProductDto>>
            (await _context.FarmerProducts.ToListAsync());

            return farmerProducts;
        }

        public async Task<FarmerProductDto> GetByIdAsync(int id)
        {
            FarmerProductDto farmerProduct = _mapper
            .Map<FarmerProductDto>
            (await _context.FarmerProducts.FindAsync(id));
            return farmerProduct;
        }

        public async Task<FarmerProductDto> UpdateAsync(FarmerProductDto entity)
        {
            FarmerProduct farmerProduct = _mapper.Map<FarmerProduct>(await GetByIdAsync(entity.FarmerProductId));
            _context.FarmerProducts.Update(farmerProduct);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
