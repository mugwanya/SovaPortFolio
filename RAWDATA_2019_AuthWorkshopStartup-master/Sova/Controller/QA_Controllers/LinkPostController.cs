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
    [Route("api/QA/linkpost")]
    public class LinkPostController : ControllerBase
    {
        IQADatabaseService _dataService;
        IMapper _mapper;
        public LinkPostController(IQADatabaseService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{linkPostId}", Name = nameof(GetLinkPostId))]
        public ActionResult GetLinkPostId(int linkPostId)
        {
            var getLinkPost = _dataService.GetLinkPostId(linkPostId);
            if (getLinkPost == null) return NotFound();
            return Ok(getLinkPost);
        }


      
        [HttpGet("{linkPostId}", Name = nameof(GetLinkPostIds))]
        public ActionResult GetLinkPostIds([FromQuery]PagingAttributes pagingAttributes)
        {
            var linkpost = _dataService.GetLinkPostIds(pagingAttributes);
            var result = CreateResult(linkpost, pagingAttributes);
            return Ok(result);

        }
        // HELPER FUNCTIONS
        private LinkPostDto CreateLinkDto(LinkPost linkpost)
        {
            var dto = _mapper.Map<LinkPostDto>(linkpost);
            dto.Link = Url.Link(
                    nameof(GetLinkPostId),
                    new { linkPostId = linkpost.PostId });
            return dto;
        }


        // Helper Method
        private object CreateResult(IEnumerable<LinkPost> linkpost, PagingAttributes attr)
        {
            var totalItems = _dataService.NumberGetLinkPost();
            var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numberOfPages - 1 ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

            return new
            {
                totalItems,
                numberOfPages,
                prev,
                next,
                items = linkpost.Select(CreateLinkDto)
            };
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetLinkPostIds), new { page, pageSize });
        }

    }
}