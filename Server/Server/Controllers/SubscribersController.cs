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
        public ActionResult<List<Subscriptions>> Get() => _subscribersRepository.GetAllSubsribers();

        [HttpGet("{id:int}")]
        public ActionResult<Subscriptions> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var sub = _subscribersRepository.GetSubsriber(id);
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

            try
            {
                return _subscribersRepository.AddSubsriber(subscriptions);
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
                return _subscribersRepository.DeleteSubsriber(id);
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
