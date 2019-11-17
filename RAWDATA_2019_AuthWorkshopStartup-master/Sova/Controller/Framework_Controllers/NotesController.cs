using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Profiles;
using AutoMapper;

namespace SovaWebAppicaltion.Controller.Framework_Controllers
{
    [ApiController]
    [Route("api/Framework/notes")]
    public class NotesController : ControllerBase
    {
        INotesService _dataService;
        IMapper _mapper;

        public NotesController(INotesService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetNotes))]
        public ActionResult GetNotes ([FromQuery] PagingAttributes pagingAttributes)
        {
            var notes = _dataService.ReadAllNotes(pagingAttributes);
            var result = CreatedResult(notes, pagingAttributes);
            return Ok(result);
        }

        [HttpGet("usernotes/{userId}", Name = nameof(GetNotesByUserId))]
        public ActionResult GetNotesByUserId(int userId, [FromQuery]PagingAttributes pagingAttributes)
        {
            var notes = _dataService.ReadAll(userId, pagingAttributes);
            if (notes == null) return NotFound();
            var result = CreatedResult(notes, pagingAttributes);
            return Ok(result);
        }

        [HttpGet("{noteId}", Name = nameof(GetNote))]
        public ActionResult GetNote(int noteId)
        {
            var note = _dataService.Read(noteId);
            if (note == null) return NotFound();
            return Ok(note);
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

        //HELPER FUNCTIONS
        private object CreatedResult(IEnumerable<Notes> notes, PagingAttributes attr)
        {
            var totalItems = _dataService.numOfPages();
            var numOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numOfPages - 1 ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

            return new
            {
                totalItems,
                numOfPages,
                prev,
                next,
                items = notes.Select(CreateNoteDto)
            };
        }

        private NoteDto CreateNoteDto(Notes note)
        {
            var dto = _mapper.Map<NoteDto>(note);
            dto.Link = Url.Link(
                nameof(GetNote),
                new { noteId = note.Id });
            return dto;
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetNotes), new { page, pageSize });
        }
    }
}
