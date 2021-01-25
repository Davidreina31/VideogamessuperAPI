using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOCAL.Interface;
using LOCAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VIDEOGAMESSUPER.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _service.Insert(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User user)
        {
            _service.Update(user);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
