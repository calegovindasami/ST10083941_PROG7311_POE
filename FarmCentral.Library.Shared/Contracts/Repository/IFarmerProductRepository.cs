
using FarmCentral.Library.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Contracts.Repository;

public interface IFarmerProductRepository : IGenericRepository<FarmerProductDto>
{
    Task<FarmerProductDto> GetByIdAsync(int id);
}
