using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public AlertController(IAlertRepository alertRepository, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }

        [HttpGet, Route("AlertForUser")]
        public async Task<IActionResult> GetAlertsForUser(string idUser)
        {
            var alerts = await _alertRepository.GetAllAsync(x => x.IdUser == idUser);

            return Ok(alerts);
        }

        [HttpPost, Route("Alert")]
        public async Task<IActionResult> Alert(AddAlertDto dto)
        {
            var alert = _mapper.Map<Alert>(dto);
            alert.IsOpen = false;
            _alertRepository.Add(alert);
            await _alertRepository.SaveChangesAsync();

            return Ok(alert);
        }
    }
}
