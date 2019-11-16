using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovaDataAccessLayer;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.FrameworkTables;

namespace SovaWebAppicaltion.Controller.Framework_Controllers
{
    [ApiController]
    [Route("api/Framework/users")]
    public class UsersController : ControllerBase
    {
        IUsersService _dataService;

        public UsersController(IUsersService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _dataService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
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
            user.id = userId;
            _dataService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser (int userId)
        {
            if (_dataService.DeleteUser(userId)) return NoContent();
            return NotFound();
        }
    }
}
