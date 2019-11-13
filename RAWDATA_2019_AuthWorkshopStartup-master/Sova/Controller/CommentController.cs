using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer;

namespace Sova.Controller
{

    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {

        IQADatabaseService _dataService;

        public CommentController (IQADatabaseService dataService)
        {
            _dataService = dataService;
        }

        //READ
        [HttpGet]
        public ActionResult<List<Comment>> GetComments()
        {
            var comments = _dataService.GetComments();
            return Ok(comments);

        }

        [HttpGet("{commentId}")]
        public ActionResult GetComment (int commentId)
        {
            var comment = _dataService.GetComment(commentId);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        //CREATE
        [HttpPost]
        public ActionResult CreateComment ([FromBody] Comment comment)
        {
            _dataService.CreateComment(comment);
            return Ok(comment);
        }

    }
}