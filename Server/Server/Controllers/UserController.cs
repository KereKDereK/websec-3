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
        public ActionResult<List<User>> Get() => _userRepository.GetAllUsers();

        [HttpGet("{id:int}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var user = _userRepository.GetUser(id);
                return user;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] User user)
        {

            try
            {
                return _userRepository.AddUser(user);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] User user)
        {

            try
            {
                return _userRepository.UpdateUser(id, user);
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
                return _userRepository.DeleteUser(id);
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
