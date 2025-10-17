using Newtonsoft.Json;
using System.Text;

namespace LocalFarmer2.Client.Services
{
    public class AlertService : IAlertService
    {
        private bool _isSuccessAlert = false;
        private bool _isDeleteAlert = false;
        private string _text = string.Empty;
        private readonly HttpClient _httpClient;
        public event Action OnAlert;

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
            OnAlert?.Invoke();
        }

        public void SetDeleteAlert(string text)
        {
            IsSuccessAlert = false;
            IsDeleteAlert = true;
            Text = text;
            OnAlert?.Invoke();
        }

        public async Task ClearAlertAfterDelay()
        {
            await Task.Delay(2000);
            Text = string.Empty;
            IsDeleteAlert = false;
            IsSuccessAlert = false;
            OnAlert?.Invoke();
        }


        public async Task<List<Alert>> GetAllForUser(string idUserTarget, int? idFarmhouse)
        {
            List<Alert> alerts;

            if (idFarmhouse != null)
            {
                alerts = await _httpClient.GetFromJsonAsync<List<Alert>>($"api/Alert/AlertForUser?idUser={idUserTarget}&idFarmhouse={idFarmhouse}");
            }
            else
            {
                alerts = await _httpClient.GetFromJsonAsync<List<Alert>>($"api/Alert/AlertForUser?idUser={idUserTarget}");
            }

            return alerts;
        }

        public async Task AddAlerts(AlertUserIds dtos, int? idFarmhouse, bool infoFromFarmhouse, MessageAlert messageAlert)
        {
            if (dtos.IdUserSource.Count == 0)
            {
                foreach (var x in dtos.IdUserTarget)
                {
                    AddAlertDto dtoAlert = new AddAlertDto()
                    {
                        IdFarmhouse = idFarmhouse,
                        Message = messageAlert.GetMessage(),
                        IdUserTarget = x,
                        IdUserSource = string.Empty,
                        InfoFromFarmhouse = infoFromFarmhouse,
                        AlertEnum = messageAlert.AlertEnum
                    };
                    await AddAlert(dtoAlert);
                }
            }
            else if (dtos.IdUserSource.Count == 1 && dtos.IdUserTarget.Count == 1)
            {
                AddAlertDto dtoAlert = new AddAlertDto()
                {
                    IdFarmhouse = idFarmhouse,
                    Message = messageAlert.GetMessage(),
                    IdUserTarget = dtos.IdUserTarget[0],
                    IdUserSource = dtos.IdUserSource[0],
                    InfoFromFarmhouse = infoFromFarmhouse,
                    AlertEnum = messageAlert.AlertEnum
                };
                await AddAlert(dtoAlert);
            }
        }

        public async Task AddAlert(AddAlertDto dto)
        {
            await _httpClient.PostAsJsonAsync($"api/Alert/Alert", dto);
        }

        public async Task SetAlertsAsRead(int[] ids)
        {
            var query = string.Join("&", ids.Select(id => $"ids={id}"));
            await _httpClient.PutAsync($"api/Alert/SetAlertsAsRead?{query}", null);
        }

        public async Task DeleteAlerts(int[] ids)
        {
            var query = string.Join("&", ids.Select(id => $"ids={id}"));
            await _httpClient.DeleteAsync($"api/Alert/DeleteAlerts?{query}");
        }
    }
}
