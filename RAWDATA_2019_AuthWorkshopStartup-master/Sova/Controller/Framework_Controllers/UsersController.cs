using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;
using AutoMapper;

namespace SovaWebAppicaltion.Controller.Framework_Controllers
{
    [ApiController]
    [Route("api/Framework/users")]
    public class UsersController : ControllerBase
    {
        IUsersService _dataService;
        IMapper _mapper;

        public UsersController(IUsersService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public ActionResult GetUsers([FromQuery] PagingAttributes pagingAttributes)
        {
            var users = _dataService.GetUsers(pagingAttributes);
            var result = CreatedResult(users, pagingAttributes);
            return Ok(result);
        }

        [HttpGet("{userId}", Name = nameof(GetUser))]
        public ActionResult GetUser(int userId)
        {
            var user = _dataService.GetUser(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] SovaDataAccessLayer.FrameworkTables.User user)
        {
            _dataService.CreateUser(user);
            return Created("", user);
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(int userId, SovaDataAccessLayer.FrameworkTables.User user)
        {
            if (!_dataService.UserExcist(userId)) return NotFound();
            user.Id = userId;
            _dataService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser (int userId)
        {
            if (_dataService.DeleteUser(userId)) return NoContent();
            return NotFound();
        }

        //HELPER FUNCTIONS
        private object CreatedResult(IEnumerable<SovaDataAccessLayer.FrameworkTables.User> users, PagingAttributes attr)
        {
            var totalItems = _dataService.numOfPages();
            var numOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 ? CreatePagingLink(attr.Page - 1, attr.PageSize) : null;

            var next = attr.Page < numOfPages - 1 ? CreatePagingLink(attr.Page + 1, attr.PageSize) : null;

            return new
            {
                totalItems,
                numOfPages,
                prev,
                next,
                items = users.Select(CreateNoteDto)
            };
        }

        private UsersDto CreateNoteDto(SovaDataAccessLayer.FrameworkTables.User user)
        {
            var dto = _mapper.Map<UsersDto>(user);
            dto.Link = Url.Link(
                nameof(GetUser),
                new { userId = user.Id });
            return dto;
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetUsers), new { page, pageSize });
        }
    }
}
