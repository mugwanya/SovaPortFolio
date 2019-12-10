using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;

namespace Sova.Controller
{

    [ApiController]
    [Route("api/qa/posts")]
    public class PostController : ControllerBase
    {

        IQADatabaseService _dataService;
        IMapper _mapper;

        public PostController(IQADatabaseService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        //READ
        [HttpGet(Name = nameof(GetPosts))]
        public ActionResult GetPosts([FromQuery]PagingAttributes pagingAttributes)
        {
            var posts = _dataService.GetPosts(pagingAttributes);
            var result = CreateResult(posts, pagingAttributes);
            return Ok(result);

        }

        [HttpGet("{postId}", Name = nameof(GetPost))]
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
        private PostDto CreatePostDto(Post post)
        {
            var dto = _mapper.Map<PostDto>(post);
            dto.Link = Url.Link(
                    nameof(GetPost),
                    new { postId = post.Id});
            return dto;
        }
        private object CreateResult(IEnumerable<Post> comments, PagingAttributes attr)
        {
            var totalItems = _dataService.NumberOfPosts();
            var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numberOfPages - 1 ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

            return new
            {
                totalItems,
                numberOfPages,
                prev,
                next,
                items = comments.Select(CreatePostDto)
            };
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetPosts), new { page, pageSize });
        }

    }
}