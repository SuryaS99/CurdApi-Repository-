using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.IRepository
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindById(Expression<Func<T, bool>> experssion);

        void Create(T entity);
        // void Update(T entity,Expression<Func<T, bool>> experssion);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> experssion);

        Task<T> GetDefault(Expression<Func<T, bool>> expression);

      //  Task<T> Upload(T entity);
        //  void DeleteDto(Expression<Func<T, bool>> experssion);
        //Task<Product> CreateProduct(Product product);
    }
}
