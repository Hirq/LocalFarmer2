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

            await _opinionRepository.AddAsync(opinion);
            await _opinionRepository.SaveChangesAsync();

            return Ok(opinion);
        }
    }
}
