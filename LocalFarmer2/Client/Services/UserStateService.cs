using LocalFarmer2.Shared.DTOs;

namespace LocalFarmer2.Client.Services
{
    public class UserStateService
    {
        private UserDto? _currentUser;
        public event Action OnUserChanged;

        public UserDto? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                NotifyUserChanged();
            }
        }

        private void NotifyUserChanged()
        {
            OnUserChanged?.Invoke();
        }
    }
}
