using MudBlazor;
using LocalFarmer2.Client.Pages;

namespace LocalFarmer2.Client.Services
{
    public class UtilsService
    {
        private readonly IDialogService _dialogService;
        private readonly HttpClient _httpClient;
        private readonly IStringLocalizer<SharedResources> _loc;

        public class DialogData
        {
            public string Title { get; set; }
            public string ButtonName { get; set; }
            public string Content { get; set; }
        }

        public UtilsService(IDialogService dialogService, HttpClient httpClient, IStringLocalizer<SharedResources> loc)
        {
            _dialogService = dialogService;
            _httpClient = httpClient;
            _loc = loc;
        }

        public void OpenDialog(DialogData dialogData, Action action, Color buttonColor)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ButtonName", dialogData.ButtonName },
                { "Content", dialogData.Content },
                { "Action", action },
                { "ColorButton", buttonColor }
            };

            _dialogService.Show<PopupDialog>(dialogData.Title, parameters, options);
        }

        public void OpenDialogWithCards(string title, List<Opinion> content)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ListOpinion", content }
                //{ "Action", action },
            };

            _dialogService.Show<PopupWithCards>(title, parameters, options);
        }

        public void OpenDialogNoteCards(string title, string buttonName, Note note, Action action, bool isEdit, Action? actionArchive, string buttonNameArchive = null)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "ButtonName", buttonName },
                { "Note", note },
                { "Action", action },
                { "IsEdit", isEdit },
                { "ActionArchive", actionArchive },
                { "ButtonNameArchive", buttonNameArchive },
            };

            _dialogService.Show<PopupDialogNote>(title, parameters, options);
        }

        public async Task OpenDialogSendMessage(bool isContactToAdmin = true, string? emailTo = null)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                { "isContactToAdmin", isContactToAdmin },
                { "emailTo", emailTo }
            };
            _dialogService.Show<PopupDialogSendMessage>(_loc["Farmhouse_Contact_Form"], parameters, options);
        }

        public async Task SendMessage(EmailDto emailDto)
        {
            await _httpClient.PostAsJsonAsync("api/Email", emailDto);
        }

        public bool FilterFunc<T>(T item, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (item is FavoriteFarmhouse favoriteFarmhouse)
            {
                if (favoriteFarmhouse.Farmhouse?.Name?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                    return true;
            }

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(item)?.ToString();
                if (!string.IsNullOrEmpty(value) &&
                    value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
