using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository _alertRepository;

        public AlertController(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        [HttpGet, Route("AlertForUser")]
        public async Task<IActionResult> GetAlertsForUser(string idUser)
        {
            var alerts = _alertRepository.GetAllAsync(x => x.IdUser == idUser);

            return Ok(alerts);
        }
    }
}
