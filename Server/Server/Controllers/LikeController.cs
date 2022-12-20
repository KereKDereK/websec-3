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
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        [HttpGet]
        public ActionResult<List<Like>> Get() => _likeRepository.GetAllLikes();

        [HttpGet("{id:int}")]
        public ActionResult<Like> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var like = _likeRepository.GetLike(id);
                return like;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Like like)
        {

            try
            {
                return _likeRepository.AddLike(like);
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
                return _likeRepository.DeleteLike(id);
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
