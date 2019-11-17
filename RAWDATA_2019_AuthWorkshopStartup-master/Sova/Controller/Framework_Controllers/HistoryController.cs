using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SovaWebAppicaltion.Controller
{
    [ApiController]
    [Route("api/Framework/history")]
    public class HistoryController : ControllerBase
    {
        IHistoryService _historyService;
        IMapper _mapper;

        public HistoryController(IHistoryService historyService, IMapper mapper)
        {
            _historyService = historyService;
            _mapper = mapper;
        }

        // GET: api/Framework/history
        [HttpGet(Name = nameof(GetHistory))]
        public ActionResult GetHistory(int userId, [FromQuery] PagingAttributes pagingAttributes)
        {
            return Ok(CreateResult(userId, pagingAttributes));
        }        

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private object CreateResult(int userId, PagingAttributes pagingAttributes)
        {
            int totalItems = _historyService.NumberofHistory(userId);
            var numberOfPages = Math.Ceiling((double)totalItems / pagingAttributes.PageSize);

            var previous = pagingAttributes.Page > 0
                ? CreatePagingLink(pagingAttributes.Page - 1, pagingAttributes.PageSize, userId)
                : null;
            var next = pagingAttributes.Page < numberOfPages - 1
                ? CreatePagingLink(pagingAttributes.Page + 1, pagingAttributes.PageSize, userId)
                : null;

            return new
            {
                totalItems,
                numberOfPages,
                previous,
                next,
                items = _historyService.ReadAll(userId, pagingAttributes)
            };
        }

        private string CreatePagingLink(int page, int pageSize, int userId)
        {
            return Url.Link(nameof(GetHistory), new { page, pageSize, userId });
        }
    }
}
