using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Account
{
    public interface IAccountServices
    {
        // Task<LoginDTO> Login(string Email, string Password);
        Task<User> login(string Email, string Password);
        //Task<Role> GetRoleNameByRoleId(int id);
    }
}
