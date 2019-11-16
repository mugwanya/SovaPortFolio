using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.FrameworkTables;

namespace SovaWebAppicaltion.Controller.Framework_Controllers
{
    [ApiController]
    [Route("api/Framework/notes")]
    public class NotesController : ControllerBase
    {
        INotesService _dataService;

        public NotesController(INotesService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult GetNotes ()
        {
            var notes = _dataService.ReadAllNotes();
            return Ok(notes);
        }

        [HttpGet("{noteId}")]
        public ActionResult GetNote(int noteId)
        {
            var note = _dataService.Read(noteId);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpGet("usernotes/{userId}")]
        public ActionResult GetNotesByUserId (int userId)
        {
            var notes = _dataService.ReadAll(userId);
            if (notes == null) return NotFound();
            return Ok(notes);
        }

        [HttpPost]
        public ActionResult CreateNotes([FromBody] Notes notes)
        {
            _dataService.Create(notes);
            return Created("", notes);
        }

        [HttpDelete("{noteId}")]
        public ActionResult DeleteNote (int noteId)
        {
            if (_dataService.Delete(noteId))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{noteId}")]
        public ActionResult UpdateNote (int noteId, Notes note)
        {
            if (!_dataService.NoteExcists(noteId)) return NotFound();
            note.Id = noteId;
            _dataService.Update(note);
            return NoContent();
        }
    }
}
