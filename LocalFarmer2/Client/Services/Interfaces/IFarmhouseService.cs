using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Client.Services
{
    public interface IFarmhouseService
    {
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<List<Farmhouse>> GetFarmhousesWithProducts();
        public Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton(int[] idsFavorites, int[] idsOpinons, int? idFarmhouse);
        public Task<Farmhouse> GetFarmhouse(int id);
        public Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse);
        public Task<int> AddFarmhouse(AddFarmhouseDto dto);
        public Task DeleteFarmhouse(int idFarmhouse);
    }
}
