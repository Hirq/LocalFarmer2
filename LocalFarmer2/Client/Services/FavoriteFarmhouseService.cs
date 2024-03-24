using LocalFarmer2.Shared.DTOs;

namespace LocalFarmer2.Client.Services
{
    public class FavoriteFarmhouseService : IFavoriteFarmhouseService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public FavoriteFarmhouseService(HttpClient http, IMapper mapper, IAccountService accountService)
        {
            _http = http;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<List<FavoriteFarmhouse>> GetFavoriteFarmhousesForUser(string userName)
        {
            var listFavoriteFarmhouses = await _http.GetFromJsonAsync<List<FavoriteFarmhouse>>($"api/FavoriteFarmhouse/FavortieFarmhouseForUser?idUser={userName}");

            if (listFavoriteFarmhouses == null)
            {
                throw new Exception();
            }

            return listFavoriteFarmhouses;
        }

        public async Task AddFavorite(int idFarmhouse)
        {
            var idUser = (await _accountService.GetCurrentUser()).IdUser;
            var dto = new FavoriteFarmhouseDto()
            {
                IdFarmhouse = idFarmhouse,
                IdUser = idUser
            };

            var favoriteFarmhouse = await _http.PostAsJsonAsync($"api/FavoriteFarmhouse/AddFavoriteFarmhouse", dto);
        }

        public async Task DeleteFavorite(int idFarmhouse)
        {
            await _http.DeleteAsync($"api/FavoriteFarmhouse/DeleteFavoriteFarmhouse/{idFarmhouse}");
        }

        public async Task<int[]> GetFavoriteFarmhousesForUserOnlyIds(string userName)
        {
            var listFavoriteFarmhouses = await _http.GetFromJsonAsync<List<int>>($"api/FavoriteFarmhouse/FavortieFarmhouseForUserOnlyIds?idUser={userName}");

            if (listFavoriteFarmhouses == null)
            {
                throw new Exception();
            }

            return listFavoriteFarmhouses.ToArray();
        }

        public async Task<List<string>> GetFavoriteFarmhouseUsersIds(int idFarmhouse)
        {
            var listFavoriteFarmhouses = await _http.GetFromJsonAsync<List<FavoriteFarmhouse>>($"api/FavoriteFarmhouse/FavortieFarmhouseForFarmhouse?idFarmhouse={idFarmhouse}");

            if (listFavoriteFarmhouses == null)
            {
                throw new Exception();
            }

            return listFavoriteFarmhouses.Select(x => x.IdUser).ToList();
        }
    }
}
