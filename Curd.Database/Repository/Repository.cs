using Curd.Database.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _repositoryContext { get; set; }
        public Repository(AppDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindById(Expression<Func<T, bool>> expression)
        {
            return _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
            _repositoryContext.SaveChanges();

        }

        public void Update(T entity)
        {

            _repositoryContext.Update(entity);
            _repositoryContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> experssion)
        {
            var category = _repositoryContext.Set<T>().Where(experssion);
            _repositoryContext.Remove(category);
            _repositoryContext.SaveChanges();
        }
        //public void DeleteDto(Expression<Func<T, bool>> experssion)
        //{
        //    var category = _repositoryContext.Set<T>().Where(experssion);
        //    _repositoryContext.Remove(category);
        //    _repositoryContext.SaveChanges();
        //}

        //public Task<Product> CreateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
