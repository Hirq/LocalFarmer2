namespace LocalFarmer2.Client.Services
{
    public interface IAlertService
    {
        public bool IsSuccessAlert { get; set; }
        public bool IsDeleteAlert { get; set; }
        public string Text { get; set; }
        public void SetSuccessAlert(string text);
        public void SetDeleteAlert(string text);
        public void ClearAlert();
        public Task<List<Alert>> GetAllForUser(string idUser, int? idFarmhouse);
        public Task SetAllAlertsAsReadForUser(string idUser);
        public Task AddAlert(AddAlertDto dto);
        public Task AddAlerts(List<string> dtos, int idFarmhouse, bool infoFromFarmhouse, MessageAlert messageAlert);
    }
}
