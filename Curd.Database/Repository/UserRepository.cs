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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext AppDbContext) : base(AppDbContext)
        {

        }

        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = new User();
            user.Id = userDto.Id;
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.RoleId = userDto.RoleId;
            if (user == null)
            {
                await _AppDbContext.User.AddAsync(user);
                await _AppDbContext.SaveChangesAsync();
            }

            return user;
        }



        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> getUser()
        {
            var user = await _AppDbContext.User.ToListAsync();
            return user;
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _AppDbContext.User.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> UpdateUser(UserDto userDto)
        {
            var user = new User();
            user.Id = userDto.Id;
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.RoleId = userDto.RoleId;
            if (userDto != null)
            {
                _AppDbContext.Entry(user).State = EntityState.Modified;
                await _AppDbContext.SaveChangesAsync();

            }
            return user;
        }
    }
}
