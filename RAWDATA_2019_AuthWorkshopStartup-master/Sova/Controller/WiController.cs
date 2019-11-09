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
    [Route("api/wis")]
    public class WiController : ControllerBase
    {

        IDatabaseServiceWI _dataService;

            public WiController(IDatabaseServiceWI dataService)
            {
                _dataService = dataService;
            }


            [HttpGet]
            public ActionResult<List<Wi>> GetWords()
            {
                var users = _dataService.GetWords();
                return Ok(users);

            }      
    }
}