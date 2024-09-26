
namespace LocalFarmer2.Client.Services
{
    public class NoteService : INoteService
    {
        Task INoteService.AddNote(Note dto)
        {
            throw new NotImplementedException();
        }

        Task INoteService.DeleteNote(int idNote)
        {
            throw new NotImplementedException();
        }

        Task INoteService.EditNote(Note dto, int idNote)
        {
            throw new NotImplementedException();
        }

        Task<List<Note>> INoteService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Note> INoteService.GetNote(int idNote)
        {
            throw new NotImplementedException();
        }

        Task<List<Note>> INoteService.GetNoteForUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
