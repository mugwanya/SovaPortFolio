using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;

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

        [HttpGet("{noteId}")]
        public ActionResult Read(int noteId)
        {
            var note = _dataService.Read(noteId);
            if (note == null) return NotFound();
            return Ok(note);
        }
    }
}
