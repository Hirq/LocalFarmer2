namespace LocalFarmer2.Server.Repositories
{
    public class AlertRepository : BaseRepository<Alert>, IAlertRepository
    {
        public AlertRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
