namespace LocalFarmer2.Shared.Utilities
{
    public class UserNotFoundException : Exception
    {
        public string UserId { get; }
        public UserNotFoundException(string userId)
            : base($"User with id '{userId}' was not found.")
        {
            UserId = userId;
        }
    }
}
