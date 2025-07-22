using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteController(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        [HttpGet, Route("AllNotes")]
        public async Task<IActionResult> AllNotes()
        {
            var notes = await _noteRepository.GetAllAsync();

            return Ok(notes);
        }

        [HttpGet, Route("GetNotesForUser")]
        public async Task<IActionResult> GetNotesForUser(string idUser)
        {
            var notes = await _noteRepository.GetAllAsync(x => x.IdUser == idUser);

            return Ok(notes);
        }

        [HttpPost, Route("AddNote")]
        public async Task<IActionResult> AddNote([FromBody] NoteDto model)
        {
            Note note = _mapper.Map<Note>(model);
            note.IsArchive = false;
            await _noteRepository.AddAsync(note);
            await _noteRepository.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut, Route("EditNote/{id}")]
        public async Task<IActionResult> EditNote([FromBody] NoteDto model, int id)
        {
            Note note = await _noteRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            note.Name = model.Name;
            note.Text = model.Text;
            note.IsArchive = model.IsArchive;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();

            return Ok(note);
        }

        [HttpDelete, Route("DeleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            Note note = await _noteRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            await _noteRepository.DeleteAsync(note);
            await _noteRepository.SaveChangesAsync();

            return Ok(note);
        }
    }
}
