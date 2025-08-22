using LocalFarmer2.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            return await _http.GetFromJsonAsync<Farmhouse>($"api/Farmhouse/Farmhouse/{id}");
        }

        public async Task<List<Farmhouse>> GetFarmhouses()
        {
            return await _http.GetFromJsonAsync<List<Farmhouse>>("api/Farmhouse/ListFarmhouses");
        }

        public async Task<List<Farmhouse>> GetFarmhousesWithProducts()
        {
            return await _http.GetFromJsonAsync<List<Farmhouse>>($"api/Farmhouse/ListFarmhousesWithProducts");
        }

        [AllowAnonymous]
        public async Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton(int[] idsFavorites, int[] idsOpinons, int? idFarmhouse)
        {
            List<Farmhouse> farmhouses;

            farmhouses = await _http.GetFromJsonAsync<List<Farmhouse>>($"api/Farmhouse/ListFarmhousesWithProducts");

            farmhouses = farmhouses.Where(x => x.Id != idFarmhouse).ToList();

            var result = _mapper.Map<List<FarmhouseViewModel>>(farmhouses);

            if (idsFavorites != null)
            {
                foreach (var vm in result.Where(x => idsFavorites.Contains(x.Id)))
                {
                    vm.IsFavorite = true;
                };
            }

            if (idsOpinons != null)
            {
                foreach (var vm in result.Where(x => idsOpinons.Contains(x.Id)))
                {
                    vm.IsCommented = true;
                };
            }

            return result;
        }

        public async Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse)
        {
            await _http.PutAsJsonAsync($"api/Farmhouse/Farmhouse/{idFarmhouse}", dto);
        }

        public async Task<int> AddFarmhouse(AddFarmhouseDto dto)
        {
            var response = await _http.PostAsJsonAsync($"api/Farmhouse/Farmhouse/", dto);

            if (response.IsSuccessStatusCode)
            {
                var farmhouse = await response.Content.ReadFromJsonAsync<Farmhouse>();
                return farmhouse.Id;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"HTTP request failed with status code {response.StatusCode}. Error message: {errorMessage}");
            }
        }

        public async Task DeleteFarmhouse(int idFarmhouse)
        {
            await _http.DeleteAsync($"api/Farmhouse/Farmhouse/{idFarmhouse}");
        }
    }
}
