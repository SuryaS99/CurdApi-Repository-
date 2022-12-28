using Curd.Database.IRepository;
using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext AppDbContext) : base(AppDbContext)
        {
        }

        public async Task<IEnumerable<Role>> getRole()
        {
            return await _AppDbContext.Role.ToListAsync();
        }

        public async Task<Role> getRoleById(int id)
        {
            var role = await _AppDbContext.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
            return role;
        }

        public async Task<Role> CreateRole(RoleDto roleDto)
        {
            var role = new Role();
            role.Id = roleDto.RoleId;
            role.Name = roleDto.RoleName;
            role.IsActive = roleDto.IsActive;
            await _AppDbContext.Role.AddAsync(role);
            await _AppDbContext.SaveChangesAsync();
            return role;

        }

        public async Task<Role> UpdateRole(RoleDto roleDto)
        {

            var role = new Role();
            role.Id = roleDto.RoleId;
            role.Name = roleDto.RoleName;
            role.IsActive = roleDto.IsActive;
            if (role != null)
            {
                _AppDbContext.Entry(role).State = EntityState.Modified;
                await _AppDbContext.SaveChangesAsync();
            }
            return role;
        }

        public async Task<Role> DeleteRole(int id)
        {
            var role = await _AppDbContext.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (role != null)
            {
                _AppDbContext.Remove(role);
                await _AppDbContext.SaveChangesAsync();
                return role;
            }

            return null;
        }

    }
}
