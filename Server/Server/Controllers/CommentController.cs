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
        public ActionResult<List<Comment>> Get()
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            return _commentRepository.GetAllComments(cookie);
        }
        [HttpGet("{id:int}")]
        public ActionResult<Comment> Get(int id)
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var comment = _commentRepository.GetComment(id, cookie).Result;
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
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _commentRepository.AddComment(comment, cookie).Result;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] Comment comment)
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _commentRepository.UpdateComment(id, comment, cookie).Result;
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
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _commentRepository.DeleteComment(id, cookie).Result;
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
