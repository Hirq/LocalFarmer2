using Blazored.LocalStorage;
using LocalFarmer2.Client.Utilities;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace LocalFarmer2.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
        }
        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Account/Register", registerModel);
            if (!result.IsSuccessStatusCode) 
            {
                return new RegisterResult
                {
                    Successful = false,
                    Errors = new List<string>
                    {
                        "Error occured"
                    }
                };
            }
            return new RegisterResult
            {
                Successful = true,
                Errors = new List<string>
                {
                     "Account create sucessfully!"
                }
            };
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("api/Account/Login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

            var loginResult = JsonSerializer.Deserialize<LoginResult>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

            if (!response.IsSuccessStatusCode) 
            {
                return loginResult!;
            }

            await _localStorageService.SetItemAsync("authToken", loginResult!.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

    }
}
