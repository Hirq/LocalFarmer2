namespace LocalFarmer2.Client.Services
{
    public interface IAlertServicePremium
    {
        public bool ShouldShowAlert(UserDto user);
        public void MarkAlertShown();
        public int GetDaysLeft(UserDto user);
    }
}
