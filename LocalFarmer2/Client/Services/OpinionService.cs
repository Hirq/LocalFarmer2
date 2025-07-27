namespace LocalFarmer2.Client.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;


        public OpinionService(
            HttpClient httpClient,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Opinion>> GetAll()
        {
            var opinions = await _httpClient.GetFromJsonAsync<List<Opinion>>("api/Opinion/AllOpinions");

            if (opinions == null)
            {
                throw new Exception("Not found any opinions");
            }

            return opinions;
        }

        public async Task<Opinion> GetOpinion(int idOpinion)
        {
            var opinion = await _httpClient.GetFromJsonAsync<Opinion>($"api/Opinion/Opinion/{idOpinion}");

            if (opinion == null)
            {
                throw new Exception($"Not found opinion id: {idOpinion}");
            }

            return opinion;
        }

        public async Task<List<Opinion>> GetOpinionFarmhousesForUser(string userName)
        {
            var listOpinionFarmhouses = await _httpClient.GetFromJsonAsync<List<Opinion>>($"api/Opinion/OpinionFarmhouseForUser?idUser={userName}");

            if (listOpinionFarmhouses == null)
            {
                throw new Exception();
            }

            return listOpinionFarmhouses;
        }

        public async Task<int[]> GetOpinionFarmhousesForUserOnlyIds(string userName)
        {
            var listOpinionFarmhouses = await _httpClient.GetFromJsonAsync<List<int>>($"api/Opinion/OpinionFarmhouseForUserOnlyIds?idUser={userName}");

            if (listOpinionFarmhouses == null)
            {
                throw new Exception("Not found object for function GetOpinionFarmhousesForUserOnlyIds");
            }

            return listOpinionFarmhouses.ToArray();
        }

        public async Task AddOpinion(AddOpinionDto dto)
        {
            var opinion = _mapper.Map<Opinion>(dto);
            opinion.DateCreated = DateTime.Now;
            await _httpClient.PostAsJsonAsync($"api/Opinion/AddOpinion", opinion);
        }

        public async Task EditOpinion(EditOpinionDto dto, int idOpinion)
        {
            await _httpClient.PutAsJsonAsync($"api/Opinion/EditOpinion/{idOpinion}", dto);
        }

        public async Task DeleteOpinion(int idOpinion)
        {
            await _httpClient.DeleteAsync($"api/Opinion/DeleteOpinion/{idOpinion}");
        }

        public async Task<List<Opinion>> AllOpinionsForFarmhouse(int idFarmhouse)
        {
            var opinions = await _httpClient.GetFromJsonAsync<List<Opinion>>($"api/Opinion/AllOpinionsForFarmhouse/{idFarmhouse}");

            if (opinions == null)
            {
                throw new Exception("Not found opinions");
            }

            return opinions;
        }

        public async Task<List<Opinion>> GetRandomOpinionsForFarmhouse(int idFarmhouse, int count)
        {
            Random rng = new Random();

            var opinions = await AllOpinionsForFarmhouse(idFarmhouse);

            var shuffledOpinion = opinions.OrderBy(_ => rng.Next()).ToList();

            var chosenOpinions = shuffledOpinion.Take(count);

            return chosenOpinions.ToList();
        }

        public async Task<double?> AverageForFarmhouse(int idFarmhouse)
        {
            var average = await _httpClient.GetFromJsonAsync<double?>($"api/Opinion/AverageForFarmhouse/{idFarmhouse}");

            return average;
        }
    }
}
