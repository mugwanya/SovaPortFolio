using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;

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

        // GET: api/Framework/history/1
        [HttpGet("{userid}", Name = nameof(GetHistory))]
        public ActionResult GetHistory(int userId, [FromQuery] PagingAttributes pagingAttributes)
        {
            return Ok(CreateResult(userId, pagingAttributes));
        }

        // GET api/Framework/history
        [HttpGet(Name = nameof(GetSingleHistory))]
        public ActionResult GetSingleHistory(int userId, DateTime timestamp)
        {
            return Ok(_historyService.Read(userId, timestamp));
        }

        // DELETE api/Framework/history/1/timestamp
        [HttpDelete("{userid}/{timestamp}")]
        public ActionResult Delete(int userid, DateTime timestamp)
        {
            if(_historyService.Delete(userid, timestamp))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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

            var histories = _historyService.ReadAll(userId, pagingAttributes);

            return new
            {
                totalItems,
                numberOfPages,
                previous,
                next,
                items = histories.Select(ConverttoHistoryModel)
            };

        }

        private string CreatePagingLink(int page, int pageSize, int userId)
        {
            return Url.Link(nameof(GetHistory), new { page, pageSize, userId });
        }

        private object ConverttoHistoryModel(History history)
        {
            var dto = _mapper.Map<HistoryModel>(history);
            dto.Link = Url.Link(nameof(GetSingleHistory), new { userId = history.userid, timestamp = history.timestamped });
            return dto;
        }
    }
}
