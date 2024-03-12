
using static System.Net.WebRequestMethods;

namespace LocalFarmer2.Client.Services
{
    public class AlertService : IAlertService
    {
        private readonly HttpClient _httpClient;
        public event Action OnAlert;
        public bool IsSuccessAlert { get; set; }
        public bool IsDeleteAlert { get; set; }
        public string Text { get; set; }

        public AlertService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetSuccessAlert(string text)
        {
            IsSuccessAlert = true;
            IsDeleteAlert = false;
            Text = text;
            OnAlert?.Invoke();
        }

        public void SetDeleteAlert(string text)
        {
            IsSuccessAlert = false;
            IsDeleteAlert = true;
            Text = text;
            OnAlert?.Invoke();
        }

        public async Task<List<Alert>> GetAllForUser(string idUser)
        {
            var alerts = await _httpClient.GetFromJsonAsync<List<Alert>>($"api/Alert/AlertForUser?idUser={idUser}");
            
            return alerts;
        }
    }
}
