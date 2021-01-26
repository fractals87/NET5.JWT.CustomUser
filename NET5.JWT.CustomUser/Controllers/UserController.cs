using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NET5.JWT.CustomUser.Data;
using NET5.JWT.CustomUser.Models;
using NET5.JWT.CustomUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5.JWT.CustomUser.Controllers
{
    public class UserController : Controller
    {

        private readonly UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = await _unitOfWork.UserRepository.Get(model.Email, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous()
        {
            return "You are Anonymous";
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated - {0}", User.Identity.Name);

    }
}
