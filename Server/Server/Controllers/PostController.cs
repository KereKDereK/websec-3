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
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public ActionResult<List<Post>> Get() => _postRepository.GetAllPosts();

        [HttpGet("{id:int}")]
        public ActionResult<Post> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var post = _postRepository.GetPost(id);
                return post;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Post post)
        {

            try
            {
                return _postRepository.AddPost(post);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] Post post)
        {

            try
            {
                return _postRepository.UpdatePost(id, post);
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
                return _postRepository.DeletePost(id);
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
