using LocalFarmer2.Client.Pages;
using MudBlazor;

namespace LocalFarmer2.Client.Services
{
    public class UtilsService
    {
        private readonly IDialogService _dialogService;

        public UtilsService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void OpenDialog(string title, string buttonName, string content, Action action, MudBlazor.Color buttonColor)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add("ButtonName", buttonName);
            parameters.Add("Content", content);
            parameters.Add("Action", action);
            parameters.Add("ColorButton", buttonColor);

            _dialogService.Show<PopupDialog>(title, parameters, options);
        }
    }
}
