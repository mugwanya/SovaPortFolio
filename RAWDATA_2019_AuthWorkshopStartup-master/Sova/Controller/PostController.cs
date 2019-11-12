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
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        IQADatabaseService _dataService;

        public PostController(IQADatabaseService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public ActionResult<List<Comment>> GetPosts()
        {
            var comments = _dataService.GetPosts();
            return Ok(comments);

        }
    }
}