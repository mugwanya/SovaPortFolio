using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;
using SovaWebAppicaltion.Model.FrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Controller.Framework_Controllers
{
    [ApiController]
    [Route("api/framework/markings")]
    public class MarkingsContoller : ControllerBase
    {
        IMarkingsService _dataService;
        IMapper _mapper;

        public MarkingsContoller (IMarkingsService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetAllMarkings))]
        public ActionResult GetAllMarkings([FromQuery]PagingAttributes pagingAttributes)
        {
            var markings = _dataService.GetAllMarkings(pagingAttributes);
            var result = CreatedResult(markings, pagingAttributes);
            return Ok(result);
        }

        [HttpGet("{markingId}", Name = nameof(GetMarking))]
        public ActionResult GetMarking (int markingId)
        {
            var marking = _dataService.GetMarking(markingId);
            if (marking == null) return NotFound();
            return Ok(marking);
        }

        [HttpGet("usermarkings/{userId}", Name = nameof(GetMakingsByUserId))]
        public ActionResult GetMakingsByUserId (int userId,
            [FromQuery] PagingAttributes pagingAttributes)
        {
            var markings = _dataService.GetMarkings(userId, pagingAttributes);
            if (markings == null) return NotFound();
            var result = CreatedResult(markings, pagingAttributes);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateMarking (MarkingForCreation markingDto)
        {
            var marking = _mapper.Map<Marking>(markingDto);
            _dataService.CreateMarking(marking);
            return CreatedAtRoute(
                nameof(GetMarking),
                new { markingId = marking.Id },
                CreateMarkingDto(marking));
        }

        [HttpPut("{markingId}")]
        public ActionResult UpdateMarking (int markingId, Marking marking)
        {
            if (!_dataService.MarkingsExcist(markingId)) return NotFound();
            marking.Id = markingId;
            _dataService.UpdateMarking(marking);
            return NoContent();
        }

        [HttpDelete("{markingId}")]
        public ActionResult DeleteMarking (int markingId)
        {
            if (_dataService.DeleteMarking(markingId)) return NoContent();
            return NotFound();
        }

        //HELPER FUNCTIONS
        private object CreatedResult(IEnumerable<Marking> marks, PagingAttributes attr)
        {
            var totalItems = _dataService.numOfPages();
            var numOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 
                ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numOfPages - 1 
                ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

            return new
            {
                totalItems,
                numOfPages,
                prev,
                next,
                items = marks.Select(CreateMarkingDto)
            };
        }

        private MarkingsDto CreateMarkingDto(Marking mark)
        {
            var dto = _mapper.Map<MarkingsDto>(mark);
            dto.Link = Url.Link(
                nameof(GetMarking),
                new { markingId = mark.Id });
            return dto;
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetAllMarkings), new { page, pageSize });
        }
    }
}
