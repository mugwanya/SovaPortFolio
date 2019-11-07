using System.Linq;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebServiceHardcodedUser.Models;

namespace WebServiceHardcodedUser.Controllers
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
            var posts = _dataService.GetPosts(Program.CurrentUserId);

            var result = posts.Select(x => new PostDto {Title = x.Title});
            return Ok(result);
        }
    }
}
