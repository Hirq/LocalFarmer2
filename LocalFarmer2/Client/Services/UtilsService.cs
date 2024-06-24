using MudBlazor;
using LocalFarmer2.Client.Pages;

namespace LocalFarmer2.Client.Services
{
    public class UtilsService
    {
        private readonly IDialogService _dialogService;
        private readonly HttpClient _httpClient;
        private readonly IStringLocalizer<SharedResources> _loc;


        public UtilsService(IDialogService dialogService, HttpClient httpClient, IStringLocalizer<SharedResources> loc)
        {
            _dialogService = dialogService;
            _httpClient = httpClient;
            _loc = loc;
        }

        public void OpenDialog(string title, string buttonName, string content, Action action, Color buttonColor)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ButtonName", buttonName },
                { "Content", content },
                { "Action", action },
                { "ColorButton", buttonColor }
            };

            _dialogService.Show<PopupDialog>(title, parameters, options);
        }

        public async Task OpenDialogSendMessage()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            
            _dialogService.Show<PopupDialogSendMessage>(_loc["Farmhouse_Contact_Form"], options);
        }

        public async Task SendMessage(EmailDto emailDto)
        {
            await _httpClient.PostAsJsonAsync("api/Email", emailDto);
        }
    }
}
