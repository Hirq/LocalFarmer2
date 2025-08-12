using Blazored.LocalStorage;
using LocalFarmer2.Client.Utilities;
using LocalFarmer2.Shared.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace LocalFarmer2.Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        private readonly UserStateService _userStateService;

        public AccountService(ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider, HttpClient httpClient, UserStateService userStateService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
            _userStateService = userStateService;
        }
        public async Task<RegisterResult> Register(RegisterDto registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Account/Register", registerModel);
            var registerResult = await result.Content.ReadFromJsonAsync<RegisterResult>();
            return registerResult!;
        }

        public async Task<LoginResult> Login(LoginDto loginModel)
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
            _userStateService.CurrentUser = await GetCurrentUser();
            _userStateService.IsUserLogged = true;

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _userStateService.CurrentUser = null;
            _userStateService.IsUserLogged = false;
        }

        public async Task<UserDto> GetCurrentUser()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userDto = await _httpClient.GetFromJsonAsync<UserDto>($"api/Account/User/ByUserName/{user.Identity.Name}");

            return userDto;
        }

        public async Task<UserDto> GetUser(string userName)
        {
            var userDto = await _httpClient.GetFromJsonAsync<UserDto>($"api/Account/User/ByUserName/{userName}");

            return userDto;
        }

        public async Task<UserDto> GetUserById(string idUser)
        {
            var userDto = await _httpClient.GetFromJsonAsync<UserDto>($"api/Account/User/ById/{idUser}");

            return userDto;
        }

        public async Task<UserDto> GetUserByFarmhouseId(int idFarmhouse)
        {
            var userDto = await _httpClient.GetFromJsonAsync<UserDto>($"api/Account/User/ByFarmhouseId/{idFarmhouse}");

            return userDto;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"api/Account/Users");

            return users;
        }


        public async Task<List<ApplicationUser>> GetUsersByIds(List<string> ids)
        {
            string queryString = string.Join("&", ids.Select(id => $"ids={id}"));
            var users = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"api/Account/UsersByIds?{queryString}");

            return users;
        }

        public async Task EditUser(EditUserDto dto)
        {
            var user = await GetCurrentUser();
            await _httpClient.PutAsJsonAsync($"api/Account/User/{user.UserName}", dto);
        }

        public async Task<bool> IsUserLogged()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            return user.Identity.IsAuthenticated;
        }

    }
}
