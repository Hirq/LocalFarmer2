using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmhouseController : ControllerBase
    {
        private readonly IFarmhouseRepository _farmhouseRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public FarmhouseController(IFarmhouseRepository farmhouseRepository,
            IMapper mapper,
            IApplicationUserRepository applicationUserRepository)
        {
            _farmhouseRepository = farmhouseRepository;
            _mapper = mapper;
            _applicationUserRepository = applicationUserRepository;
        }

        [HttpGet, Route("ListFarmhouses")]
        public async Task<IActionResult> GetFarmhouses()
        {
            var farmhouses = await _farmhouseRepository.GetAllAsync();

            return Ok(farmhouses);
        }

        [HttpGet, Route("ListFarmhousesWithProducts")]
        public async Task<IActionResult> GetFarmhousesWithProducts()
        {
            IEnumerable<Farmhouse> farmhouses = await _farmhouseRepository.GetAllAsync(x => true, x => x.Products);

            return Ok(farmhouses);
        }

        [HttpGet, Route("Farmhouse/{id}")]
        public async Task<IActionResult> GetFarmhouse(int id)
        {
            Farmhouse farmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id, x => x.Products);

            if (farmhouse == null)
            {
                return NotFound(new { Message = $"Farmhouse with id {id} not found." });
            }

            return Ok(farmhouse);
        }

        [HttpPost, Route("Farmhouse")]
        public async Task<IActionResult> AddFarmhouse(AddFarmhouseDto dto)
        {
            var user = await _applicationUserRepository.GetFirstOrDefaultAsync(x => x.Id == dto.IdUser);

            if (user == null)
            {
                return NotFound(new { Message = $"User with id {dto.IdUser} not found." });
            }

            if (user.IdFarmhouse != null)
            {
                return Conflict(new
                {
                    Message = "You already have a farmhouse. Delete the old one first."
                });
            }

            Farmhouse farmhouse = _mapper.Map<Farmhouse>(dto);

            _farmhouseRepository.Add(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            user.IdFarmhouse = farmhouse.Id;
            await _applicationUserRepository.UpdateAsync(user);
            await _applicationUserRepository.SaveChangesAsync();

            return CreatedAtAction
            (
                nameof(GetFarmhouse),
                new { id = farmhouse.Id },
                farmhouse
            );
        }

        [HttpPut, Route("Farmhouse/{id}")]
        public async Task<IActionResult> PutFarmhouse([FromBody] FarmhouseDto dto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFarmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingFarmhouse == null)
            {
                return NotFound(new { Message = $"Farmhouse with id {id} not found." });
            }

            _mapper.Map(dto, existingFarmhouse);

            _farmhouseRepository.Update(existingFarmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(existingFarmhouse);
        }

        [HttpDelete, Route("Farmhouse/{id}")]
        public async Task<IActionResult> DeleteFarmhouse(int id)
        {
            var farmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (farmhouse == null)
            {
                return NotFound(new { Message = $"Farmhouse with id {id} not found." });
            }

            var user = await _applicationUserRepository.GetFirstOrDefaultAsync(x => x.IdFarmhouse == id);
            if (user == null)
            {
                return BadRequest(new { Message = "You can't delete a farmhouse without an owner." });
            }

            user.IdFarmhouse = null;
            await _applicationUserRepository.UpdateAsync(user);
            await _applicationUserRepository.SaveChangesAsync();

            await _farmhouseRepository.DeleteAsync(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}