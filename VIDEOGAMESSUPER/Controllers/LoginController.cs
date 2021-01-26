using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOCAL.Interface;
using LOCAL.Models;
using Microsoft.AspNetCore.Mvc;
using Token.tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VIDEOGAMESSUPER.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        protected TokenManager _tokenManager { get; }
        private IUserService _userService;

        public LoginController(TokenManager tokenManager, IUserService userService)
        {
            _tokenManager = tokenManager;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginCredentials loginCredentials)
        {
            if(loginCredentials?.EmailAdress == null || loginCredentials?.Password == null)
            {
                return BadRequest();
            }

            User userFound = _userService.CorrectUser(loginCredentials.EmailAdress, loginCredentials.Password);

            if(userFound == null)
            {
                return StatusCode(401);
            }

            string token = "";

            if (userFound != null)
            {
                token = _tokenManager.GenerateJwt(new TokenData()
                {
                    UserId = userFound.UserId,
                    UserName = userFound.UserName,
                    Role = userFound.Admin == true? "Admin" : "User"
                });
            }

            return Ok(new { token });
        }
    }
}
