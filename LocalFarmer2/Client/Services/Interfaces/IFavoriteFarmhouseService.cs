namespace LocalFarmer2.Client.Services
{
    public interface IFavoriteFarmhouseService
    {
        public Task<List<FavoriteFarmhouse>> GetFavoriteFarmhousesForUser(string userName);
        public Task AddFavorite(int idFarmhouse);
        public Task DeleteFavorite(int idFarmhouse);
    }
}
