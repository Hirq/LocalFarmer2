namespace LocalFarmer2.Client.Services
{
    public interface IFavoriteFarmhouseService
    {
        public Task<List<FavoriteFarmhouse>> GetFavoriteFarmhousesForUser(string userName);
    }
}
