﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<Like>> Get()
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            return _likeRepository.GetAllLikes(cookie);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Like> Get(int id)
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
                var like = _likeRepository.GetLike(id, cookie).Result;
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
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _likeRepository.AddLike(like, cookie).Result;
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
                return _likeRepository.DeleteLike(id, cookie).Result;
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
