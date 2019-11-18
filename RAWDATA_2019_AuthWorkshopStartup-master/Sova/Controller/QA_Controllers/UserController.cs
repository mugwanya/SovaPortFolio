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
    [Route("api/QA/users")]
    public class UserController : ControllerBase
    {
        IQADatabaseService _dataService;
        IMapper _mapper;

        public UserController(IQADatabaseService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
       

        [HttpGet(Name = nameof(QAGetUsers))]
        public ActionResult QAGetUsers([FromQuery]PagingAttributes pagingAttributes)
        {

            var users = _dataService.QAGetUsers(pagingAttributes);
            var result = CreateResult(users, pagingAttributes);
            return Ok(result);

        }


 
        [HttpGet("{userId}", Name = nameof(QAGetUser))]
        public ActionResult QAGetUser(int userId)
        {
            var users = _dataService.QAGetUser(userId);
            if (users == null) return NotFound();
            return Ok(users);
        }

        // HELPER FUNCTIONS
        private UserDto CreateUserDto(User user)
        {
            var dto = _mapper.Map<UserDto>(user);
            dto.Link = Url.Link(
                    nameof(QAGetUser),
                    new { userId = user.Id });
            return dto;
        }


        // Helper Method
        private object CreateResult(IEnumerable<User> users, PagingAttributes attr)
        {
            var totalItems = _dataService.NumberOfUsers();
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
            return Url.Link(nameof(QAGetUsers), new { page, pageSize });
        }

    }
}