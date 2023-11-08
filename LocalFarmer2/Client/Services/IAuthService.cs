using LocalFarmer2.Shared.Utilities;
using LocalFarmer2.Shared.ViewModels;

namespace LocalFarmer2.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();

        Task<UserModel> GetUser(string userName);
    }
}
