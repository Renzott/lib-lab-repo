using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using creditos_backend.Authetication.Interfaces;
using creditos_backend.Models;
using creditos_backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace creditos_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _confuguration;
        private readonly IJWTUserLogin _jwtUser;

        public UserController(IUserRepository userRepository,IConfiguration configuration, IJWTUserLogin jwtUser)
        {
            _userRepository = userRepository;
            _confuguration = configuration;
            _jwtUser = jwtUser;
        }

        // POST api/user/mail

        [HttpPost]
        [Route("mail")]
        public async Task<ActionResult<User>> GetByMail([FromBody]User user)
        {
            var item = await _userRepository.FindUserByMail(user.Mail);

            return  item ?? (ActionResult<User>) NoContent();
        }

        // POST api/user/login

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody]User user)
        {
            var item = await _userRepository.FindUserByMailPwd(user.Mail, user.password);

            var token = item != null ? _jwtUser.GenerateJSONWebToken(item) :null;

            return token != null? Ok(token) : Problem(detail:"Credenciales Incorrectas",statusCode:201);
        }

    }
}
