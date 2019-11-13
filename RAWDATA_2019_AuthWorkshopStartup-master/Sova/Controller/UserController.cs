using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer;

namespace Sova.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        IQADatabaseService _dataService;

        public UserController(IQADatabaseService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _dataService.GetUsers();
            return Ok(users);

        }

        [HttpGet("{userId}")]
        public ActionResult GetUser (int userId)
        {
            var user = _dataService.GetUser(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}