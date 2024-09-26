namespace LocalFarmer2.Client.Services
{
    public interface INoteService
    {
        public Task<List<Note>> GetAll();
        public Task<Note> GetNote(int idNote);
        public Task<List<Note>> GetNoteForUser(string userName);
        public Task AddNote(Note dto);
        public Task EditNote(Note dto, int idNote);
        public Task DeleteNote(int idNote);
    }
}
