using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace LocalFarmer2.Client.Services
{
    public class AlertServicePremium : IAlertServicePremium
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string SessionKey = "PremiumAlertShown";

        public AlertServicePremium(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetDaysLeft(ApplicationUser user)
            => (int)Math.Ceiling((user.DatePremium - DateTime.UtcNow).TotalDays);


        public void MarkAlertShown()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.SetString(SessionKey, DateTime.UtcNow.ToString("yyyy-MM-dd"));
        }

        public bool ShouldShowAlert(ApplicationUser user)
        {
            if (!user.IsPremium || user.DatePremium == null)
                return false;

            var daysLeft = (user.DatePremium - DateTime.UtcNow).TotalDays;
            if (daysLeft > 7 || daysLeft < 0)
                return false;

            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null) return false;

            var lastShown = session.GetString(SessionKey);
            if (lastShown == DateTime.UtcNow.ToString("yyyy-MM-dd"))
                return false;

            return true;
        }
    }
}
