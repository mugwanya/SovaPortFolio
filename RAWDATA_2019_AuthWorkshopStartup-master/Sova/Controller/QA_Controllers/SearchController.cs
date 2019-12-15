using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sova.Controller;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;
using SovaDataAccessLayer.FrameworkTables;


namespace SovaWebAppicaltion.Controller.QA_Controllers
{
    [ApiController]
    [Route("api/qa/search")]

    public class SearchController : ControllerBase
    {
        ISearchDataService _searchService;
        IQADatabaseService _dataService;
        IMapper _mapper;


        public SearchController(
            ISearchDataService searchService,
            IQADatabaseService dataService,
            IMapper mapper)
        {
            _searchService = searchService;
            _dataService = dataService;
            _mapper = mapper;

        }

        // GET: api/QA/search/Simple/1
        [HttpGet("Simple/{userid}/{query}", Name = nameof(SimpleSearch))]
        public ActionResult SimpleSearch(int userId, string query)
        {
            List<int> postid = _searchService.SimpleSearch(userId, query);
            List<Post> results = new List<Post>();
            foreach (int pid in postid)
            {
                results.Add(_dataService.GetPost(pid));
            }
            return Ok(results);
        }

        // GET: api/QA/search/Best/1
        [HttpGet("Best/{userid}/{query}", Name = nameof(BestSearch))]
        public ActionResult BestSearch(int userId, string query)
        {
            string[] keywords = query.Split(' ');
            List<BestResults> postid = _searchService.BestSearch(userId, keywords);
            List<Post> results = new List<Post>();
            foreach (BestResults pid in postid)
            {
                results.Add(_dataService.GetPost(pid.postId));
            }
            return Ok(results);
        }

        //helper functions

        private PostDto CreatePostDto(Post post)
        {
            var dto = _mapper.Map<PostDto>(post);
            dto.Link = Url.Link(
                    nameof(Sova.Controller.PostController.GetPost),
                    new { postId = post.Id });
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
            return Url.Link(nameof(Sova.Controller.PostController.GetPosts), new { page, pageSize });
        }

    }
}
