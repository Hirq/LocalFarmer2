using AutoMapper;
using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Shared.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<Farmhouse, FarmhouseDto>();
            CreateMap<Farmhouse, FarmhouseViewModel>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
