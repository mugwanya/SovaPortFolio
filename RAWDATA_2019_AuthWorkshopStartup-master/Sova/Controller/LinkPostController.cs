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
    [Route("api/QA/linkpost")]
    public class LinkPostController : ControllerBase
    {
        IQADatabaseService _dataService;

        public LinkPostController(IQADatabaseService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public ActionResult<List<LinkPost>> GetLinkPostId()
        {
            var linkpost = _dataService.GetLinkPostId();
            return Ok(linkpost);

        }
    }
}