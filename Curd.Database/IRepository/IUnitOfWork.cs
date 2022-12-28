using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.IRepository
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }

    }
}
