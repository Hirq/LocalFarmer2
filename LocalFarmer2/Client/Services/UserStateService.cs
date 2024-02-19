namespace LocalFarmer2.Client.Services
{
    public class UserStateService
    {
        public bool IsUserLogged { get; set; }

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
