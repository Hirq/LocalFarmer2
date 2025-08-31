using Microsoft.AspNetCore.Components;


namespace LocalFarmer2.Client.Pages
{
    public abstract class BasePage : ComponentBase
    {
        protected bool isLoading = false;
        protected string? errorMessage;

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
    }
}