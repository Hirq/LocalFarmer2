using LocalFarmer2.Server.Data.Migrations;
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
            var favoritesFarmhouses = await _favoriteFarmhouseRepository.GetAllAsync(x => x.IdUser == idUser, x => x.Farmhouse);

            return Ok(favoritesFarmhouses);
        }

        [HttpGet, Route("FavortieFarmhouseForFarmhouse")]
        public async Task<IActionResult> GetFavoritesFarmhousesForFarmhouse(int idFarmhouse)
        {
            var favoritesFarmhouses = await _favoriteFarmhouseRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse);

            return Ok(favoritesFarmhouses);
        }

        [HttpPost, Route("FavoriteFarmhouse")]
        public async Task<IActionResult> AddFavorite(FavoriteFarmhouseDto dto)
        {
            FavoriteFarmhouse favoriteFarmhouse = _mapper.Map<FavoriteFarmhouse>(dto);

            _favoriteFarmhouseRepository.Add(favoriteFarmhouse);
            await _favoriteFarmhouseRepository.SaveChangesAsync();

            return Ok(favoriteFarmhouse);
        }

        [HttpDelete, Route("FavoriteFarmhouse/{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            FavoriteFarmhouse favoriteFarmhouse = await _favoriteFarmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            await _favoriteFarmhouseRepository.DeleteAsync(favoriteFarmhouse);
            await _favoriteFarmhouseRepository.SaveChangesAsync();

            return Content($"Delete object favorite {id} where IdFarmhouse is {favoriteFarmhouse.IdFarmhouse}");
        }
    }
}
