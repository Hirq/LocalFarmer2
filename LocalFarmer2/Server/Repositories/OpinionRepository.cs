namespace LocalFarmer2.Server.Repositories
{
    public class OpinionRepository : BaseRepository<Opinion>, IOpinionRepository
    {
        public OpinionRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
