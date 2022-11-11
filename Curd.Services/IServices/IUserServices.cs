using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Users
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> getUser();
        Task<User> getUserById(int id);
        Task<User> CreateUser(UserDto userDto);
        Task<User> UpdateUser(UserDto userDto);
        Task<User> DeleteUser(int id);
    }
}
