using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFarmhouseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteFarmhouseRepository _favoriteFarmhouseRepository;

        public FavoriteFarmhouseController(
            IMapper mapper,
            IFavoriteFarmhouseRepository favoriteFarmhouseRepository)
        {
            _mapper = mapper;
            _favoriteFarmhouseRepository = favoriteFarmhouseRepository;
        }

        [HttpGet, Route("AllFavoritesFarmhouses")]
        public async Task<IActionResult> GetFavoritesFarmhouses()
        {
            var favoritesFarmhouses = await _favoriteFarmhouseRepository.GetAllAsync();

            return Ok(favoritesFarmhouses);
        }

        [HttpGet, Route("FavortieFarmhouseForUser")]
        public async Task<IActionResult> GetFavoritesFarmhousesForUser(string idUser)
        {
            var favoritesFarmhouses = await _favoriteFarmhouseRepository.GetAllAsync(x => x.IdUser == idUser);

            return Ok(favoritesFarmhouses);
        }

        [HttpGet, Route("FavortieFarmhouseForFarmhouse")]
        public async Task<IActionResult> GetFavoritesFarmhousesForFarmhouse(int idFarmhouse)
        {
            var favoritesFarmhouses = await _favoriteFarmhouseRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse);

            return Ok(favoritesFarmhouses);
        }
    }
}
