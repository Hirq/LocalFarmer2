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
            var opinion = await _httpClient.GetFromJsonAsync<Opinion>($"api/Opinion/Opinion{idOpinion}");

            if (opinion == null)
            {
                throw new Exception($"Not found opinion id: {idOpinion}");
            }

            return opinion;
        }

        public async Task AddOpinion(AddOpinionDto dto, int idFarmhouse)
        {
            var opinion = _mapper.Map<Opinion>(dto);
            await _httpClient.PostAsJsonAsync($"api/Opinion/AddOpinion/{idFarmhouse}", opinion);
        }

        public async Task EditOpinion(EditOpinionDto dto, int idFarmhouse)
        {
            var opinion = _mapper.Map<Opinion>(dto);
            await _httpClient.PutAsJsonAsync($"api/Opinion/EditOpinion/{idFarmhouse}", opinion);
        }

        public async Task DeleteOpinion(int idOpinion)
        {
            await _httpClient.DeleteAsync($"api/Opinion/DeleteOpinion/{idOpinion}");
        }
    }
}
