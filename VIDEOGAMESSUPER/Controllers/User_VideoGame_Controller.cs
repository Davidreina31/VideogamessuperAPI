using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOCAL.Interface;
using LOCAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VIDEOGAMESSUPER.Controllers
{
    [Route("api/[controller]")]
    public class User_VideoGame_Controller : Controller
    {
        private IUser_VideoGame_Service _service;

        public User_VideoGame_Controller(IUser_VideoGame_Service service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetOneUser(int id)
        {
            return Ok(_service.GetOne(id));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetVideoGameByUserId(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User_VideoGame user_VideoGame)
        {
            _service.Insert(user_VideoGame);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User_VideoGame user_VideoGame)
        {
            _service.Update(user_VideoGame);
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
