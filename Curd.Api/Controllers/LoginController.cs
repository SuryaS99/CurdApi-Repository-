using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Account;
using Curd.Services.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountServices _service;
        private readonly ITokenServices _tokenService;
        private readonly IConfiguration _config;
        public LoginController(IAccountServices service, ITokenServices tokenService, IConfiguration config)
        {
            _service = service;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto LoginDTO)
        {
            LoginDto _login = await _service.login(LoginDTO.Email, LoginDTO.Password);

            if (_login == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = await _tokenService.CreateToken(_login);
            return Ok(token);
        }
    }
}
