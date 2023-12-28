using LocalFarmer2.Server.Utilities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
//using Microsoft.AspNetCore.JsonPatch;
//using Swashbuckle.AspNetCore.Annotations;

//TODO: Pozwracać kody opdowiednie
//POST 201
//DELETE 204

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

            return Ok(farmhouse);
        }

        [HttpPost, Route("Farmhouse")]
        public async Task<IActionResult> AddFarmhouse(AddFarmhouseDto dto)
        {
            Farmhouse farmhouse = _mapper.Map<Farmhouse>(dto);

            _farmhouseRepository.Add(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();
            var user = await _applicationUserRepository.GetFirstOrDefaultAsync(x => x.Id == dto.IdUser);
            
            if (user.IdFarmhouse != null)
            {
                throw new Exception("You have Farmhouse. First delete old farmhouse, next add new.");
            }

            user.IdFarmhouse = farmhouse.Id;
            await _applicationUserRepository.UpdateAsync(user);
            await _applicationUserRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpPut, Route("Farmhouse/{id?}")]
        [SwaggerOperationFilter(typeof(ReApplyOptionalRouteParameterOperationFilter))]
        public async Task<IActionResult> PutFarmhouse(FarmhouseDto dto, int id = 0)
        {
            Farmhouse farmhouse = _mapper.Map<Farmhouse>(dto);

            if (id != 0)
            {
                farmhouse.Id = id;
            }

            _farmhouseRepository.Update(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpPatch, Route("Farmhouse/{id}")]
        public async Task<IActionResult> PatchFarmhouse([FromBody] JsonPatchDocument<FarmhouseDto> dto, int id)
        {
            Farmhouse farmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            var farmhouseDto = _mapper.Map<FarmhouseDto>(farmhouse);

            dto.ApplyTo(farmhouseDto);

            _mapper.Map(farmhouseDto, farmhouse);

            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpPatch, Route("Farmhouse2/{id}")]
        public async Task<IActionResult> PatchFarmhouse2([FromBody] FarmhouseDto dto, int id)
        {
            Farmhouse farmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            _mapper.Map(dto, farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpDelete, Route("Farmhouse/{id}")]
        public async Task<IActionResult> DeleteFarmhouse(int id)
        {
            Farmhouse farmhouse = await _farmhouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            await _farmhouseRepository.DeleteAsync(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Content($"Delete object farmhouse {id}");
        }

    }
}