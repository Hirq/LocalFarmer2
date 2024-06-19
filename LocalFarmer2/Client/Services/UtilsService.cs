using MudBlazor;
using LocalFarmer2.Client.Pages;

namespace LocalFarmer2.Client.Services
{
    public class UtilsService
    {
        private readonly IDialogService _dialogService;
        private readonly HttpClient _httpClient;


        public UtilsService(IDialogService dialogService, HttpClient httpClient)
        {
            _dialogService = dialogService;
            _httpClient = httpClient;
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

        public async Task OpenDialogSendMessage(string title, string buttonName, string emailFrom, Color buttonColor)
        {
            EmailDto emailDto = new EmailDto();
            var result = await _httpClient.PostAsJsonAsync("api/Email", emailDto);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ButtonName", buttonName },
                { "EmailFrom", emailFrom },
                { "ColorButton", buttonColor }
            };

            _dialogService.Show<PopupDialogSendMessage>(title, parameters, options);
        }
    }
}
