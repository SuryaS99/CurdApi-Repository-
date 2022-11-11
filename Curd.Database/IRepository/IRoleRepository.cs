using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> getRole();
        Task<Role> getRoleById(int id);

        Task<Role> CreateRole(RoleDto roleDto);
        Task<Role> UpdateRole(RoleDto roleDto);
        Task<Role> DeleteRole(int id);
        //object getRoleById(Role role);
    }
}
