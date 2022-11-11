using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Roles;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _service;

        public RoleController(IRoleServices service)
        {
            _service = service;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("Roles")]
        public async Task<IEnumerable<Role>> getRole()
        {
            var role = await _service.getRole();
            return role;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("Role/{id}")]
        public async Task<Role> getRoleById(int id)
        {
            var role = await _service.getRoleById(id);
            return role;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Role")]
        public Task<Role> CreateRole(RoleDto roleDto)
        {
            var role = _service.CreateRole(roleDto);
            return role;
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("Role/{id}")]
        public async Task<Role> UpdateRole(RoleDto roleDto)
        {
            var role = await _service.UpdateRole(roleDto);
            return role;
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("Role/{id}")]
        public async Task<Role> DeleteRole(int id)
        {
            var role = await _service.DeleteRole(id);
            return role;
        }
    }
}
