using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Client.Services
{ 
    public interface IFarmhouseService
    {
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<List<Farmhouse>> GetFarmhousesWithProducts();
        public Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton(int? idFarmhouse);
        public Task<Farmhouse> GetFarmhouse(int id);
        public Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse);
    }
}
