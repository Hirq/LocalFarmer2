using LocalFarmer2.Client.Pages.Product;
using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.ViewModels;
using System.Net.Http.Json;

namespace LocalFarmer2.Client.Services
{
    public class FarmhouseService : IFarmhouseService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public FarmhouseService(HttpClient http,
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

        public async Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton()
        {
            var farmhouses = await _http.GetFromJsonAsync<List<Farmhouse>>($"api/Farmhouse/ListFarmhousesWithProducts");

            if (farmhouses == null)
            {
                throw new Exception();
            }

            var result = _mapper.Map<List<FarmhouseViewModel>>(farmhouses);

            return result;
        }

        public async Task EditFarmhouse(FarmhouseDto dto, int idFarmhouse)
        {
            Farmhouse farmhouse = _mapper.Map<Farmhouse>(dto);
            await _http.PutAsJsonAsync($"api/Farmhouse/Farmhouse/{idFarmhouse}", farmhouse);
        }
    }
}
