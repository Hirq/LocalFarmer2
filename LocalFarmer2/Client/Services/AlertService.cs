namespace LocalFarmer2.Client.Services
{
    public class AlertService : IAlertService
    {
        private bool _isSuccessAlert = false;
        private bool _isDeleteAlert = false;
        private string _text = string.Empty;

        public bool IsSuccessAlert
        {
            get => _isSuccessAlert;
            set
            {
                _isSuccessAlert = value;
                OnAlert?.Invoke();
            }
        }

        public bool IsDeleteAlert
        {
            get => _isDeleteAlert;
            set
            {
                _isDeleteAlert = value;
                OnAlert?.Invoke();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnAlert?.Invoke();
            }
        }
        private readonly HttpClient _httpClient;
        public event Action OnAlert;


        public AlertService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            IsSuccessAlert = false;
            IsDeleteAlert = false;
        }

        public void SetSuccessAlert(string text)
        {
            IsSuccessAlert = true;
            IsDeleteAlert = false;
            Text = text;
        }

        public void SetDeleteAlert(string text)
        {
            IsSuccessAlert = false;
            IsDeleteAlert = true;
            Text = text;
        }

        public async Task<List<Alert>> GetAllForUser(string idUser)
        {
            var alerts = await _httpClient.GetFromJsonAsync<List<Alert>>($"api/Alert/AlertForUser?idUser={idUser}");
            
            return alerts;
        }

        public async Task SetAllAlertsAsReadForUser(string idUser)
        {
            await _httpClient.PutAsync($"api/Alert/SetAllAlertsAsReadForUser?idUser={idUser}", null);
        }
    }
}
