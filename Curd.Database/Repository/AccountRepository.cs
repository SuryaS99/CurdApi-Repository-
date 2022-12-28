using Curd.Database.IRepository;
using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.Repository
{
    public class AccountRepository : Repository<LoginDto>, IAccountRepository
    {
        //private readonly IUnitOfWork _unitOfWork;

        public AccountRepository(AppDbContext AppDbContext) : base(AppDbContext)
        {
           
        }
        
        //public async Task<User> login(string Email, string Password)
        //{

        //     return await UserRepository.GetDefault(x => x.Email == Email && x.Password == Password);
        //    //var loginDto = await (from u in _AppDbContext.User
        //    //                    //  join r in _AppDbContext.Role
        //    //                     // on u.RoleId equals r.Id
        //    //                      where u.Email == Email & u.Password == Password
        //    //                      select new UserDto
        //    //                      {
        //    //                          Email = u.Email,
        //    //                          Password = u.Password,
        //    //                          RoleId = u.RoleId,
        //    //                          //RoleName = r.Name
        //    //                      }).FirstOrDefaultAsync();
        //    //return loginDto;
        //}


        //public async Task<User> checkValidtion(string Email, string Password)
        //{
        //    //We have join 2 table i.e roles and user and get some new data mail,pass,roleId and role_Name
        //    var loginDto =await (from u in _repositoryContext.User
        //                      where u.Email == Email & u.Password == Password
        //                      select u
        //                      ).FirstOrDefaultAsync();
        //    return loginDto;
        //}

        //public async Task<Role> GetRoleNameByRoleId(int id)
        //{
        //    var role = await(from u in _repositoryContext.User
        //                     join r in _repositoryContext.Role
        //                     on u.RoleId equals r.Id
        //                     select r).FirstOrDefaultAsync();
        //    return role;
        //}
    }
}
