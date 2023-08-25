
using Microsoft.AspNetCore.Mvc;
using System;

namespace KeepNote_Step3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // POST: api/note
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            try
            {
                var createdNote = _noteRepository.Create(note);
                return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.NoteId }, createdNote);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to create note." });
            }
        }

        // GET: api/note/{id}
        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _noteRepository.GetById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // GET: api/note
        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return Ok(notes);
        }

        // PUT: api/note/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note note)
        {
            try
            {
                _noteRepository.Update(id, note);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to update note." });
            }
        }

        // DELETE: api/note/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            try
            {
                _noteRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to delete note." });
            }
        }
    }
}
