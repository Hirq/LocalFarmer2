namespace LocalFarmer2.Server.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
