using MudBlazor;
using LocalFarmer2.Client.Pages;

namespace LocalFarmer2.Client.Services
{
    public class UtilsService
    {
        private readonly IDialogService _dialogService;

        public UtilsService(IDialogService dialogService)
        {
            _dialogService = dialogService;
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

        public void OpenDialogSendMessage(string title, string buttonName, Action action, string emailTo, Color buttonColor)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ButtonName", buttonName },
                { "Action", action },
                { "EmailTo", emailTo },
                { "ColorButton", buttonColor }
            };

            _dialogService.Show<PopupDialogSendMessage>(title, parameters, options);
        }
    }
}
