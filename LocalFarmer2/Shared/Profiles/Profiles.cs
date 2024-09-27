using AutoMapper;
using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Shared.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<AddFarmhouseDto, Farmhouse>();
            CreateMap<Farmhouse, FarmhouseDto>();
            CreateMap<Farmhouse, FarmhouseViewModel>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<FavoriteFarmhouse, FavoriteFarmhouseDto>();
            CreateMap<FavoriteFarmhouseDto, FavoriteFarmhouse>();
            CreateMap<UserDto, EditUserDto>();
            CreateMap<AddOpinionDto, Opinion>();
            CreateMap<AddAlertDto, Alert>();
            CreateMap<NoteDto, Note>();
            CreateMap<Note, NoteDto>();
        }
    }
}
