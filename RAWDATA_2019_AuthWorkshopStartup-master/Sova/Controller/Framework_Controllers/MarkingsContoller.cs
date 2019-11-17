using Microsoft.AspNetCore.Mvc;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
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

        public MarkingsContoller (IMarkingsService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult GetAllMarkings()
        {
            var markings = _dataService.GetAllMarkings();
            return Ok(markings);
        }

        [HttpGet("{markingsId}")]
        public ActionResult GetMarking (int markingsId)
        {
            var marking = _dataService.GetMarking(markingsId);
            return Ok(marking);
        }

        [HttpGet("usermarkings/{userId}")]
        public ActionResult GetMakingsByUserId (int userId)
        {
            var markings = _dataService.GetMarkings(userId);
            if (markings == null) return NotFound();
            return Ok(markings);
        }

        [HttpPost]
        public ActionResult CreateMarking ([FromBody] Marking marking)
        {
            _dataService.CreateMarking(marking);
            return NoContent();
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
    }
}
