namespace LocalFarmer2.Client.Services
{
    public interface IAlertServicePremium
    {
        public bool ShouldShowAlert(ApplicationUser user);
        public void MarkAlertShown();
        public int GetDaysLeft(ApplicationUser user);
    }
}
