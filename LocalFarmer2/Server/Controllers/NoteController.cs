using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
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
        public async Task<IActionResult> AllOpinions()
        {
            var notes = await _noteRepository.GetAllAsync();

            return Ok(notes);
        }
        [HttpPost, Route("AddNote")]

        public async Task<IActionResult> AddNote([FromBody] Note model)
        {
            await _noteRepository.AddAsync(model);
            await _noteRepository.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut, Route("EditNote/{id}")]
        public async Task<IActionResult> EditNote([FromBody] Note model, int id)
        {
            Note note = await _noteRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            note.Name = model.Name;
            note.Text = model.Text;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();

            return Ok(note);
        }
    }
}
