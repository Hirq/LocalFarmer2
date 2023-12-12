namespace LocalFarmer2.Client.Services
{
    public class FavoriteFarmhouseService : IFavoriteFarmhouseService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public FavoriteFarmhouseService(HttpClient http, IMapper mapper)
        {
            _http = http;
            _mapper = mapper;
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
    }
}
