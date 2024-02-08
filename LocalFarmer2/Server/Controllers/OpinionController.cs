using Microsoft.AspNetCore.Http;
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

            return Ok(opinion);
        }

        [HttpGet, Route("Opinion/{id}")]
        public async Task<IActionResult> Opinion(int id)
        {
            Opinion opinion = await _opinionRepository.GetFirstOrDefaultAsync(x => x.Id == id, x => x.Farmhouse, x => x.ApplicationUser);

            return Ok(opinion);
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
            await _opinionRepository.DeleteAsync(opinion);

            return Ok();
        }
    }
}
