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
    public class UsersController : ControllerBase
    {


        IDatabaseServiceUsers _dataService;

        public UsersController(IDatabaseServiceUsers dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _dataService.GetUsers();
            return Ok(users);
        }
    }
}