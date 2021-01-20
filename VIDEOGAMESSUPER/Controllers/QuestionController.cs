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
    public class QuestionController : Controller
    {
        private IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        // GET: api/values
        //[HttpGet]
        //public IActionResult GetOne(int id)
        //{
        //    return Ok(_service.GetOne(id));
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            _service.Insert(question);
            return Ok();
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
