using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Utilities;

namespace LocalFarmer2.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterDto registerModel);
        Task<LoginResult> Login(LoginDto loginModel);
        Task Logout();
        Task<UserDto> GetUser(string userName);
    }
}
