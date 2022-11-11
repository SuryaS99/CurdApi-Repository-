using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.IRepository
{
    public interface IAccountRepository : IRepository<LoginDto>
    {
        Task<LoginDto> login(string Email, string Password);
        //Task<Role> GetRoleNameByRoleId(int id);
    }
}
