using Curd.Database.IRepository;
using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Account
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _account;

        public AccountServices(IAccountRepository account)
        {
            _account = account;
        }

        public async Task<LoginDto> login(string Email, string Password)
        {
            var account = await _account.login(Email, Password);
            return account;
        }

        //public Task<Role> GetRoleNameByRoleId(int id)
        //{
        //    var role = _account.GetRoleNameByRoleId(id);
        //    return role;
        //}
        //  public Task<> Login(LoginDTO login);
    }
}
