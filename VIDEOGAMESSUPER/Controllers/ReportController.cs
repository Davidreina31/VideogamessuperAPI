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
    public class ReportController : Controller
    {
        private IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Report report)
        {
            _service.Insert(report);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Report report)
        {
            _service.Update(report);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
