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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            return _userRepository.GetAllUsers(cookie);
        }
        [HttpGet("{id:int}")]
        public ActionResult<List<Post>> Get(int id)
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
                var user = _userRepository.GetUser(id, cookie);
                return user.Item1;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Key code)
        {

            try
            {
                string cookie = "string";
                HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie);
                Tuple<int, string> result = _userRepository.AddUser(code.code, cookie).Result;
                if (result.Item1 == -1)
                    return -1;
                HttpContext.Response.Cookies.Append("auth_token", result.Item2, 
                    new Microsoft.AspNetCore.Http.CookieOptions
                    {
                    Expires = DateTimeOffset.Now.AddDays(10).AddMinutes(-5),
                    SameSite = SameSiteMode.None,
                    Secure = true
                    });

                HttpContext.Response.Cookies.Append("id", result.Item1.ToString(),
                    new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(10).AddMinutes(-5),
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });

                return 1;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] User user)
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _userRepository.UpdateUser(id, user, cookie);
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
                return _userRepository.DeleteUser(id, cookie);
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
