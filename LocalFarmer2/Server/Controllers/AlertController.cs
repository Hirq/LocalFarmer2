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
        public async Task<IActionResult> GetAlertsForUser(string idUser, int? idFarmhouse)
        {
            IEnumerable<Alert> alerts;

            if (idFarmhouse != null)
            {
                alerts = await _alertRepository.GetAllAsync(x => x.IdUser == idUser || x.IdFarmhouse == idFarmhouse, x => x.Farmhouse);
            }
            else
            {
                alerts = await _alertRepository.GetAllAsync(x => x.IdUser == idUser, x => x.Farmhouse);
            }

            return Ok(alerts);
        }

        [HttpPost, Route("Alert")]
        public async Task<IActionResult> Alert(AddAlertDto dto)
        {
            var alert = _mapper.Map<Alert>(dto);
            alert.IsOpen = false;
            alert.DateCreated = DateTime.Now;
            _alertRepository.Add(alert);
            await _alertRepository.SaveChangesAsync();

            return Ok(alert);
        }

        [HttpPut, Route("SetAllAlertsAsReadForUser")]
        public async Task<IActionResult> SetAllAlertsAsReadForUser(string idUser)
        {
            var alerts = (await _alertRepository.GetAllAsync(x => x.IdUser == idUser)).ToList();
            alerts.ForEach(x => x.IsOpen = true);
            await _alertRepository.SaveChangesAsync();

            return Ok(alerts);
        }
    }
}
