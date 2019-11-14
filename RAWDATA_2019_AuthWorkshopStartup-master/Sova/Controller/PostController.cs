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

        //READ
        [HttpGet]
        public ActionResult<List<Comment>> GetPosts()
        {
            var posts = _dataService.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public ActionResult GetPost(int postId)
        {
            var post = _dataService.GetPost(postId);
            if (post == null) return NotFound();
            return Ok(post);
        }

        //CREATE
        [HttpPost]
        public ActionResult CreatePost ([FromBody] Post post)
        {
            _dataService.CreatePost(post);
            return Created("", post);
        }

        //UPDATE
        [HttpPut("{postId}")]
        public ActionResult UpdatePost(int postId, Post post)
        {
            if (!_dataService.PostExcist(postId))
            {
                return NotFound();
            }
            post.Id = postId;
            _dataService.UpdatePost(post);
            return NoContent();
        }
        //DELETE
        [HttpDelete("{postId}")]
        public ActionResult DeletePost(int postId)
        {
            if (_dataService.DeletePost(postId))
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}