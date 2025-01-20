using LocalFarmer2.Shared.Utilities;

namespace LocalFarmer2.Client.Services
{
    public interface IAccountService
    {
        Task<RegisterResult> Register(RegisterDto registerModel);
        Task<LoginResult> Login(LoginDto loginModel);
        Task Logout();
        Task<UserDto> GetCurrentUser();
        Task<UserDto> GetUser(string userName);
        Task<UserDto> GetCurrentUserByFarmhouseId(int idFarmhouse);
        Task<List<ApplicationUser>> GetUsers();
        Task EditUser(EditUserDto dto);
        Task<bool> IsUserSignUp();
    }
}
