using Curd.Database.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        public IProductsRepository ProductsRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public  IUserRepository UserRepository { get; }

        public UnitOfWork(IUserRepository userRepository,
            ICategoryRepository categoryRepository, 
            IProductsRepository productsRepository, 
            IRoleRepository roleRepository, 
            IAccountRepository accountRepository)
        {
            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
            ProductsRepository = productsRepository;
            RoleRepository = roleRepository;
            AccountRepository = accountRepository;
        }
    }
}
