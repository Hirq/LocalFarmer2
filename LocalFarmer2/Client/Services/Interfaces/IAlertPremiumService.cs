namespace LocalFarmer2.Client.Services
{
    public interface IAlertPremiumService
    {
        bool ShouldShowAlert(DateTime datePremium, bool isPremium);
        Task<bool> WasAlertShownTodayAsync();
        Task MarkAlertShownAsync();
        int GetDaysLeft(DateTime datePremium);
    }
}
