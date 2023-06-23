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
        //Maps all the DTOs to the database models.
        CreateMap<Farmer, FarmerDto>().ReverseMap();
        CreateMap<FarmerProduct, FarmerProductDto>()
            .ForMember(s => s.ProductName, d => d.MapFrom(map => map.Product.ProductName))
            .ForMember(s => s.ProductType, d => d.MapFrom(map => map.Product.ProductType!.ProductTypeName))
            .ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductType, ProductDto>().ReverseMap();
    }
}
