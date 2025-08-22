using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IOpinionRepository _opinionRepository;
        private readonly IMapper _mapper;

        public OpinionController(
            UserManager<IdentityUser> userManager,
            IApplicationUserRepository applicationUserRepository,
            IOpinionRepository opinionRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
            _opinionRepository = opinionRepository;
            _mapper = mapper;
        }

        [HttpPost, Route("AddOpinion")]
        public async Task<IActionResult> AddOpinion([FromBody] AddOpinionDto model)
        {
            Opinion opinion = _mapper.Map<Opinion>(model);
            opinion.DateCreated = DateTime.Now;
            await _opinionRepository.AddAsync(opinion);
            await _opinionRepository.SaveChangesAsync();

            return CreatedAtAction
            (
                nameof(Opinion),
                new { id = opinion.Id },
                opinion
            );
        }

        [HttpGet, Route("Opinion/{id}")]
        public async Task<IActionResult> Opinion(int id)
        {
            Opinion opinion = await _opinionRepository.GetFirstOrDefaultAsync(x => x.Id == id, x => x.Farmhouse, x => x.ApplicationUser);

            if (opinion == null)
            {
                return NotFound(new { Message = $"Opinion with id {id} not found." });
            }

            return Ok(opinion);
        }

        [HttpGet, Route("OpinionFarmhouseForUser")]
        public async Task<IActionResult> GetFavoritesFarmhousesForUser(string idUser)
        {
            var opinonsFarmhouses = await _opinionRepository.GetAllAsync(x => x.IdUser == idUser, x => x.Farmhouse);

            return Ok(opinonsFarmhouses);
        }

        [HttpGet, Route("OpinionFarmhouseForUserOnlyIds")]
        public async Task<IActionResult> GetOpinonFarmhousesForUserOnlyIds(string idUser)
        {
            var opinonsFarmhouses = (await _opinionRepository.GetAllAsync(x => x.IdUser == idUser)).Select(x => x.IdFarmhouse);

            return Ok(opinonsFarmhouses);
        }

        [HttpGet, Route("AllOpinions")]
        public async Task<IActionResult> AllOpinions()
        {
            var opinion = await _opinionRepository.GetAllAsync();

            return Ok(opinion);
        }

        [HttpPut, Route("EditOpinion/{id}")]
        public async Task<IActionResult> EditOpinion([FromBody] EditOpinionDto model, int id)
        {
            Opinion opinion = await _opinionRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (opinion == null)
            {
                return NotFound(new { Message = $"Opinion with id {id} not found." });
            }

            opinion.Comment = model.Comment;
            opinion.Rating = model.Rating;

            _opinionRepository.Update(opinion);
            await _opinionRepository.SaveChangesAsync();

            return Ok(opinion);
        }

        [HttpDelete, Route("DeleteOpinion/{id}")]
        public async Task<IActionResult> DeleteOpinion(int id)
        {
            Opinion opinion = await _opinionRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (opinion == null)
            {
                return NotFound(new { Message = $"Opinion with id {id} not found." });
            }

            await _opinionRepository.DeleteAsync(opinion);
            await _opinionRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet, Route("AllOpinionsForFarmhouse/{idFarmhouse}")]
        public async Task<IActionResult> AllOpinionsForFarmhouse(int idFarmhouse)
        {
            var allValue = (await _opinionRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse));

            return Ok(allValue);
        }

        [HttpGet, Route("AverageForFarmhouse/{idFarmhouse}")]
        public async Task<IActionResult> AverageForFarmhouse(int idFarmhouse)
        {
            var allValue = (await _opinionRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse)).Select(x => x.Rating);

            if (allValue.Any())
            {
                var average = allValue.Average();
                return Ok(average);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
