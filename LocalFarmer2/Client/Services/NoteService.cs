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
            return await _httpClient.GetFromJsonAsync<List<Note>>("api/Note/AllNotes");
        }

        public async Task<List<Note>> GetNotesForUser(string idUser)
        {
            return await _httpClient.GetFromJsonAsync<List<Note>>($"api/Note/GetNotesForUser?idUser={idUser}");
        }

        public async Task<Note> GetNote(int idNote)
        {
            return await _httpClient.GetFromJsonAsync<Note>($"api/Note/Note/{idNote}");
        }

        public async Task AddNote(Note model)
        {
            var dto = _mapper.Map<NoteDto>(model);

            await _httpClient.PostAsJsonAsync($"api/Note/AddNote", dto);
        }

        public async Task DeleteNote(int idNote)
        {
            await _httpClient.DeleteAsync($"api/Note/DeleteNote/{idNote}");
        }

        public async Task EditNote(Note model)
        {
            var dto = _mapper.Map<NoteDto>(model);

            await _httpClient.PutAsJsonAsync($"api/Note/EditNote/{model.Id}", dto);
        }
    }
}
