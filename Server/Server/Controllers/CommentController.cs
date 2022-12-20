using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Server.Repositories;
using System.Collections.Generic;
using Server.Models;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public ActionResult<List<Comment>> Get() => _commentRepository.GetAllComments();

        [HttpGet("{id:int}")]
        public ActionResult<Comment> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var comment = _commentRepository.GetComment(id);
                return comment;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Comment comment)
        {

            try
            {
                return _commentRepository.AddComment(comment);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] Comment comment)
        {

            try
            {
                return _commentRepository.UpdateComment(id, comment);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{id:int}")]

        public ActionResult<int> Delete(int id)
        {
            try
            {
                return _commentRepository.DeleteComment(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
