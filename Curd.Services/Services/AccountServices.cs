using Curd.Database.IRepository;
using Curd.Model.Models;
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
        private readonly IUserRepository _userRepository;
        public AccountServices(IUserRepository userRepository)
        {
          
            _userRepository = userRepository;
        }
        public async Task<User> login(string Email, string Password)
        {
            var account = await _userRepository.GetDefault(x => x.Email == Email && x.Password == Password);
            return account;
        }
    }
}
