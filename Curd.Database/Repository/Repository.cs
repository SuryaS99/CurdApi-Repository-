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
    public class Repository<T> : IRepository<T> where T: class
    {
        protected AppDbContext _AppDbContext { get; set; }
        public Repository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return _AppDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindById(Expression<Func<T, bool>> expression)
        {
            return _AppDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _AppDbContext.Set<T>().Add(entity);
            _AppDbContext.SaveChanges();

        }

        public void Update(T entity)
        {

            _AppDbContext.Update(entity);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> experssion)
        {
            var category = _AppDbContext.Set<T>().Where(experssion);
            _AppDbContext.Remove(category);
            _AppDbContext.SaveChanges();
        }

        public virtual async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _AppDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        //public async Task<T> Upload(T entity)
        //{
        //   await _AppDbContext.Set<T>().AddAsync(entity);
        //    await _AppDbContext.SaveChangesAsync();

        //    return entity;
        //}

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
