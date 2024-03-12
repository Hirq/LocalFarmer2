namespace LocalFarmer2.Client.Services
{
    public interface IAlertService
    {
        public Task<List<Alert>> GetAllForUser(string idUser);
    }
}
