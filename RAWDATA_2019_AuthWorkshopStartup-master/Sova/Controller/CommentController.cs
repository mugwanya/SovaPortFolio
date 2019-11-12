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


        [HttpGet]
        public ActionResult<List<Comment>> GetComments()
        {
            var comments = _dataService.GetComments();
            return Ok(comments);

        }


    }
}