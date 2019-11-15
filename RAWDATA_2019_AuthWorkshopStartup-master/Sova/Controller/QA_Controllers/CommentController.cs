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
    [Route("api/QA/comments")]
    public class CommentController : ControllerBase
    {

        IQADatabaseService _dataService;
        IMapper _mapper;

        public CommentController (IQADatabaseService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        //READ
        [HttpGet(Name = nameof(GetComments))]
        public ActionResult GetComments([FromQuery]PagingAttributes pagingAttributes)
        {
            var comments = _dataService.GetComments(pagingAttributes);
            var result = CreateResult(comments, pagingAttributes);
            return Ok(result);

        }

        [HttpGet("{commentId}", Name = nameof(GetComment))]
        public ActionResult GetComment (int commentId)
        {
            var comment = _dataService.GetComment(commentId);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        //CREATE
        [HttpPost]
        public ActionResult CreateComment ([FromBody] Comment comment)
        {
            _dataService.CreateComment(comment);
            return Created("", comment);

        }

        //UPDATE
        [HttpPut ("{commentId}")]
        public ActionResult UpdateComment (int commentId, Comment comment)
        {
            if (!_dataService.CommentExcist(commentId))
            {
                return NotFound();
            }
            comment.Id = commentId;
            _dataService.UpdateComment(comment);
            return NoContent();
        }

        //DELETE
        [HttpDelete ("{commentId}")]
        public ActionResult DeleteComment (int commentId)
        {
            if (_dataService.DeleteComment(commentId))
            {
                return NoContent();
            }
            return NotFound();
        }

        private CommentDto CreateCommentDto(Comment comment)
        {
            var dto = _mapper.Map<CommentDto>(comment);
            dto.Link = Url.Link(
                    nameof(GetComment),
                    new { commentId = comment.Id });
            return dto;
        }


        private object CreateResult(IEnumerable<Comment> comments, PagingAttributes attr)
        {
            var totalItems = _dataService.NumberOfComments();
            var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0 ? CreatePagingLink(attr.Page - 1, attr.PageSize): null;

            var next = attr.Page < numberOfPages - 1 ? CreatePagingLink(attr.Page + 1, attr.PageSize): null;

            return new
            {
                totalItems,
                numberOfPages,
                prev,
                next,
                items = comments.Select(CreateCommentDto)
            };
        }

        // This Method Creates 
        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetComments), new { page, pageSize });
        }
    }
}