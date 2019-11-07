using System.Linq;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebServiceSimple.Models;

namespace WebServiceSimple.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public PostsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            if (Program.CurrentUser == null)
                return Unauthorized();

            var posts = _dataService.GetPosts(Program.CurrentUser.Id);

            var result = posts.Select(x => new PostDto { Title = x.Title });
            return Ok(result);
        }
    }
}
