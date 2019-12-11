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
using SovaWebAppicaltion.Model;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("markings/{markingId}", Name = nameof(GetNotesByMarkingId))]
        public ActionResult GetNotesByMarkingId(int markingId,
            [FromQuery]PagingAttributes pagingAttributes)
        {
            var notes = _dataService.ReadByMarking(markingId, pagingAttributes);
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
        public ActionResult CreateNotes(NoteForCreation noteDto)
        {
            var note = _mapper.Map<Notes>(noteDto);
            _dataService.Create(note);
            return CreatedAtRoute(
                nameof(GetNote),
                new { noteId = note.Id},
                CreateNoteDto(note));
        }

        [HttpPut("{noteId}")]
        public ActionResult UpdateNote (int noteId, Notes note)
        {
            if (!_dataService.NoteExcists(noteId)) return NotFound();
            note.Id = noteId;
            _dataService.Update(note);
            return NoContent();
        }

        [HttpDelete("{noteId}")]
        public ActionResult DeleteNote(int noteId)
        {
            if (_dataService.Delete(noteId))
            {
                return NoContent();
            }
            return NotFound();
        }

        //HELPER FUNCTIONS
        private object CreatedResult(IEnumerable<Notes> notes, PagingAttributes attr)
        {
            var totalItems = _dataService.numOfPages();
            var numOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 
                ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numOfPages - 1 
                ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

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

            dto.MarkingLink = Url.Link(
                nameof(GetMarking),
                new { markingId = note.Markingid});

            return dto;
        }

        private object GetMarking()
        {
            throw new NotImplementedException();
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetNotes), new { page, pageSize });
        }
    }
}
