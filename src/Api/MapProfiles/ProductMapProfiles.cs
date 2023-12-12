using AutoMapper;
using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Models;

namespace SimpleShop.src.Api.MapProfiles;

#pragma warning disable CS1591
public class ProductMapProfile : Profile
{
    public ProductMapProfile()
    {
        CreateMap<Product, GetProductResponse>();
            
    }
}