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
        Task<LoginDto> login(string Email, string Password);
        //Task<Role> GetRoleNameByRoleId(int id);
    }
}
