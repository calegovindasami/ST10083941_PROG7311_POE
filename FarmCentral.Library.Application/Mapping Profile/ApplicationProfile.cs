using AutoMapper;
using FarmCentral.Library.Application.Models;
using FarmCentral.Library.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Application.Mapping_Profile;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Farmer, FarmerDto>().ReverseMap();
        CreateMap<FarmerProduct, FarmerProductDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<OutgoingTransaction, OutgoingTransactionDto>().ReverseMap();
    }
}
