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

namespace SovaWebAppicaltion.Controller.QA_Controllers
{
    [ApiController]
    [Route("api/QA/search")]

    public class SearchController : ControllerBase
    {
        ISearchDataService _searchService;
        IQADatabaseService _dataService;

        public SearchController(ISearchDataService searchService, IQADatabaseService dataService)
        {
            _searchService = searchService;
            _dataService = dataService;
        }

        // GET: api/QA/search/Simple/1
        [HttpGet("Simple/{userid}", Name = nameof(SimpleSearch))]
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
        [HttpGet("Best/{userid}", Name = nameof(BestSearch))]
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
    }
}