using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Client.Services
{
    public class FarmhouseService : IFarmhouseService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public FarmhouseService(
            HttpClient http,
            IMapper mapper)
        {
            _http = http;
            _mapper = mapper;
        }

        public async Task<Farmhouse> GetFarmhouse(int id)
        {
            var result = await _http.GetFromJsonAsync<Farmhouse>($"api/Farmhouse/Farmhouse/{id}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<List<Farmhouse>> GetFarmhouses()
        {
            var result = await _http.GetFromJsonAsync<List<Farmhouse>>("api/Farmhouse/ListFarmhouses");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<List<Farmhouse>> GetFarmhousesWithProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Farmhouse>>($"api/Farmhouse/ListFarmhousesWithProducts");

            if (result == null)
            {
                throw new Exception();
            }

            //result = new List<Farmhouse>();

            return result;
        }

        public async Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton(int[] idsFavorites, int? idFarmhouse)
        {
            List<Farmhouse> farmhouses;

            farmhouses = await _http.GetFromJsonAsync<List<Farmhouse>>($"api/Farmhouse/ListFarmhousesWithProducts");

            if (farmhouses == null)
            {
                throw new Exception();
            }

            if (idFarmhouse != null)
            {
                farmhouses = farmhouses.Where(x => x.Id != idFarmhouse).ToList();
            }

            var result = _mapper.Map<List<FarmhouseViewModel>>(farmhouses);

            if (idsFavorites != null)
            {
                foreach (var vm in result.Where(x => idsFavorites.Contains(x.Id)))
                {
                    vm.IsFavorite = true;
                };
            }

            return result;
        }

        public async Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse)
        {
            //TODO: 
            //Zrobić bez mapowania - czy dziala
            Farmhouse farmhouse = _mapper.Map<Farmhouse>(dto);
            await _http.PutAsJsonAsync($"api/Farmhouse/Farmhouse/{idFarmhouse}", farmhouse);
        }

        public async Task AddFarmhouse(AddFarmhouseDto dto)
        {
            await _http.PostAsJsonAsync($"api/Farmhouse/Farmhouse/", dto);
        }

        public async Task DeleteFarmhouse(int idFarmhouse)
        {
            await _http.DeleteAsync($"api/Farmhouse/Farmhouse/{idFarmhouse}");
        }
    }
}
