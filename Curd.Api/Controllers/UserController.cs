using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [Authorize(Policy = "All")]
        [HttpGet]
        [Route("Users")]
        public async Task<IEnumerable<User>> getUser()
        {
            var user = await _services.getUser();
            return user;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("User/{id}")]
        public async Task<User> getUserById(int id)
        {
            var user = await _services.getUserById(id);
            return user;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("User")]
        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = await _services.CreateUser(userDto);
            return user;
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("User/{id}")]
        public async Task<User> UpdateUser(UserDto userDto)
        {
            var user = await _services.UpdateUser(userDto);
            return user;
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("User/{id}")]
        public async Task<User> DeleteUser(int id)
        {
            var user = await _services.DeleteUser(id);
            return user;
        }
    }
}
