using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Account;
using Curd.Services.Roles;
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
        private readonly IAccountServices _accountService;
        private readonly ITokenServices _tokenService;
        private readonly IConfiguration _config;
        private readonly IRoleServices _roleServices;

        public LoginController(IAccountServices accountService, ITokenServices tokenService, IConfiguration config, IRoleServices roleServices)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _config = config;
            _roleServices = roleServices;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto LoginDTO)
        {
            var _login = await _accountService.login(LoginDTO.Email, LoginDTO.Password);

            if (_login != null)
            {
                var role = await _roleServices.getRoleById(_login.RoleId);
                LoginDto loginDto = new LoginDto();
                loginDto.Email = _login.Email;
                loginDto.Password = _login.Password;
                //loginDto.RoleId = _login.RoleId;
               
                return Ok(await _tokenService.CreateToken(loginDto));
            }
            return Unauthorized("Invalid Credentials");

        }
    }
}
