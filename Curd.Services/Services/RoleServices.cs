using Curd.Database.IRepository;
using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Roles
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _role;

        public RoleServices(IRoleRepository role)
        {
            _role = role;
        }
        public Task<Role> CreateRole(RoleDto roleDto)
        {
            var role = _role.CreateRole(roleDto);
            return role;
        }

        public Task<Role> DeleteRole(int id)
        {
            var role = _role.DeleteRole(id);
            return role;
        }

        public Task<IEnumerable<Role>> getRole()
        {
            var role = _role.getRole();
            return role;
        }

        public Task<Role> getRoleById(int id)
        {
            var role = _role.getRoleById(id);
            return role;
        }

        public Task<Role> UpdateRole(RoleDto roleDto)
        {
            var role = _role.UpdateRole(roleDto);
            return role;
        }
    }
}
