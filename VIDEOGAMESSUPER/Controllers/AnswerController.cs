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
    public class AnswerController : Controller
    {
        private IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetByQuestionId(id));
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Answer answer)
        {
            _service.Insert(answer);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Answer answer)
        {
            _service.Update(answer);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
