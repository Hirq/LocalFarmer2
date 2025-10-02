using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Client.Services
{
    public interface IFarmhouseService
    {
        Task<List<Farmhouse>> GetFarmhouses();
        Task<List<Farmhouse>> GetFarmhousesWithProducts();
        Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton(int[] idsFavorites, int[] idsOpinions, int? idFarmhouse);
        Task<Farmhouse> GetFarmhouse(int id);
        Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse);
        Task<int> AddFarmhouse(AddFarmhouseDto dto);
        Task DeleteFarmhouse(int idFarmhouse);
    }
}
