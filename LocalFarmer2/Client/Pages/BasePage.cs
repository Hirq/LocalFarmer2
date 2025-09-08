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
                Console.WriteLine("LoadDataAsync try end");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                isLoading = false;
                Console.WriteLine("LoadDataAsync finally end");
            }
        }

        protected abstract Task LoadDataAsync();
    }
}