using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer;
using SovaDataAccessLayer.QATables;

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


        [HttpGet(Name = nameof(GetLinkPostIds))]
        public ActionResult GetLinkPostIds([FromQuery]PagingAttributes pagingAttributes)
        {
            var linkpost = _dataService.GetPosts(pagingAttributes);
            var result = CreateResult(linkpost, pagingAttributes);
            return Ok(result);

        }
        // HELPER FUNCTIONS
        private LinkPostDto CreateUserDto(LinkPost user)
        {
            var dto = _mapper.Map<LinkPost>(user);
            dto.Link = Url.Link(
                    nameof(GetUser),
                    new { userId = user.Id });
            return dto;
        }


        // Helper Method
        private object CreateResult(IEnumerable<User> users, PagingAttributes attr)
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
                items = users.Select(CreateUserDto)
            };
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetUsers), new { page, pageSize });
        }

    }
}