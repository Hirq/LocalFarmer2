using LocalFarmer2.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LocalFarmer2.Client.Pages
{
    public abstract class BasePage : ComponentBase
    {
        [Inject] protected IAccountService AccountService { get; set; }
        [Inject] protected UserStateService UserStateService { get; set; }
        [Inject] protected IStringLocalizer<SharedResources> Loc { get; set; }
        protected virtual string NotLoggedInMessage => Loc?["ErrorUserIsNotLogged"] ?? "User is not logged in.";
        protected virtual string MissingFarmhouseMessage => Loc?["ErrorUserDoesnotHaveFarmhouse"] ?? "User does not have farmhouse.";
        protected virtual string OwnerFarmhouseMessage => Loc?["ErrorUserDoesHaveFarmhouse"] ?? "User does have farmhouse.";

        protected bool isLoading = false;
        protected string? errorMessage;
        public bool HasError => !string.IsNullOrEmpty(errorMessage);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                errorMessage = null;

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                isLoading = false;
            }
        }
        protected abstract Task LoadDataAsync();

        protected async Task<bool> EnsureLoggedInAsync()
        {
            var isLogged = await AccountService.IsUserLogged();
            if (!isLogged)
            {
                errorMessage = NotLoggedInMessage;
                return false;
            }

            var user = await AccountService.GetCurrentUser();
            if (user == null)
            {
                errorMessage = NotLoggedInMessage;
                return false;
            }

            UserStateService.CurrentUser = user;
            return true;
        }

        protected async Task<bool> EnsureHasFarmhouseAsync()
        {
            var user = UserStateService.CurrentUser ?? await AccountService.GetCurrentUser();
            if (user == null || user.IdFarmhouse == null)
            {
                errorMessage = MissingFarmhouseMessage;
                return false;
            }
            return true;
        }
        protected async Task<bool> EnsureHasnotFarmhouseAsync()
        {
            var user = UserStateService.CurrentUser ?? await AccountService.GetCurrentUser();
            if (user == null || user.IdFarmhouse != null)
            {
                errorMessage = OwnerFarmhouseMessage;
                return false;
            }
            return true;
        }
    }
}