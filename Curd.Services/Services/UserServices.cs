using Curd.Database.IRepository;
using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _user;

        public UserServices(IUserRepository user)
        {
            _user = user;
        }
        public Task<User> CreateUser(UserDto userDto)
        {
            var user = _user.CreateUser(userDto);
            return user;
        }

        public Task<User> DeleteUser(int id)
        {
            var user = _user.DeleteUser(id);
            return user;
        }

        public Task<IEnumerable<User>> getUser()
        {
            var user = _user.getUser();
            return user;
        }

        public Task<User> getUserById(int id)
        {
            var user = _user.getUserById(id);
            return user;
        }

        public Task<User> UpdateUser(UserDto userDto)
        {
            var user = _user.UpdateUser(userDto);
            return user;
        }
    }
}
