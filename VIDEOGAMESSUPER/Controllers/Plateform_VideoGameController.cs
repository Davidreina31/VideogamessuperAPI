using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOCAL.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VIDEOGAMESSUPER.Controllers
{
    [Route("api/[controller]")]
    public class Plateform_VideoGameController : Controller
    {
        private IPlateform_VideoGameService _plateform_VideoGameservice;

        public Plateform_VideoGameController(IPlateform_VideoGameService plateform_VideoGameService)
        {
            _plateform_VideoGameservice = plateform_VideoGameService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_plateform_VideoGameservice.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_plateform_VideoGameservice.GetByVideoGameId(id));
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
