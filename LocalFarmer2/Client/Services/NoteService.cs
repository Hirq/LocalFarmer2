namespace LocalFarmer2.Client.Services
{
    public class NoteService : INoteService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public NoteService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<Note>> GetAll()
        {
            var notes = await _httpClient.GetFromJsonAsync<List<Note>>("api/Note/AllNotes");

            if (notes == null)
            {
                throw new Exception("Not found any notes");
            }

            return notes;
        }

        public async Task<Note> GetNote(int idNote)
        {
            var note = await _httpClient.GetFromJsonAsync<Note>($"api/Note/Note/{idNote}");

            if (note == null)
            {
                throw new Exception($"Not found note id: {idNote}");
            }

            return note;
        }

        public async Task AddNote(Note dto)
        {
            var note = _mapper.Map<NoteDto>(dto);

            await _httpClient.PostAsJsonAsync($"api/Note/AddNote", note);
        }

        public async Task DeleteNote(int idNote)
        {
            await _httpClient.DeleteAsync($"api/Note/DeleteNote/{idNote}");
        }

        public async Task EditNote(Note dto, int idNote)
        {
            var note = _mapper.Map<NoteDto>(dto);

            await _httpClient.PutAsJsonAsync($"api/Note/EditNote/{idNote}", note);
        }

        //TODO:
        public async Task<List<Note>> GetNoteForUser(string userName)
        {
            var notesPerUser = await _httpClient.GetFromJsonAsync<List<Note>>($"api/Note/xxxx?idUser={userName}");

            if (notesPerUser == null)
            {
                throw new Exception();
            }

            return notesPerUser;
        }
    }
}
