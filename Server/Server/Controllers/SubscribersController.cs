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
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscribersRepository _subscribersRepository;
        public SubscribersController(ISubscribersRepository subscribersRepository)
        {
            _subscribersRepository = subscribersRepository;
        }
        [HttpGet]
        public ActionResult<List<Subscriptions>> Get()
        { 
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            return _subscribersRepository.GetAllSubsribers(cookie);
        }
        [HttpGet("{id:int}")]
        public ActionResult<Subscriptions> Get(int id)
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
                var sub = _subscribersRepository.GetSubsriber(id, cookie);
                return sub;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Subscriptions subscriptions)
        {
            string cookie = "string";
            if (HttpContext.Request.Cookies.TryGetValue("auth_token", out cookie) == false)
                return Problem();
            try
            {
                return _subscribersRepository.AddSubsriber(subscriptions, cookie).Result;
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
                return _subscribersRepository.DeleteSubsriber(id, cookie).Result;
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
