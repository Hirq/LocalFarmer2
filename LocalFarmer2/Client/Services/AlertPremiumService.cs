using Microsoft.JSInterop;

namespace LocalFarmer2.Client.Services
{
    public class AlertPremiumService : IAlertPremiumService
    {
        private readonly IJSRuntime _js;

        public AlertPremiumService(IJSRuntime js)
        {
            _js = js;
        }

        public bool ShouldShowAlert(DateTime datePremium, bool isPremium)
        {
            if (!isPremium) return false;

            var daysLeft = (datePremium - DateTime.UtcNow).TotalDays;
            return daysLeft >= 0 && daysLeft <= 7;
        }

        public async Task<bool> WasAlertShownTodayAsync()
        {
            var stored = await _js.InvokeAsync<string>("localStorage.getItem", "PremiumAlertShown");
            return stored == DateTime.UtcNow.ToString("yyyy-MM-dd");
        }

        public async Task MarkAlertShownAsync()
        {
            await _js.InvokeVoidAsync("localStorage.setItem", "PremiumAlertShown",
                DateTime.UtcNow.ToString("yyyy-MM-dd"));
        }

        public int GetDaysLeft(DateTime datePremium)
            => (int)Math.Ceiling((datePremium - DateTime.UtcNow).TotalDays);
    }
}
