using Curd.Database.IRepository;
using Curd.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<Category>> getCategory()
        {
            var category = await (from c in _AppDbContext.Categories
                                  select c).ToListAsync();
            return category;
        }

        public async Task<Category> getCategoryById(int id)
        {
            var category = await _AppDbContext.Categories.
                Where(c => c.CategoryId == id).FirstOrDefaultAsync();
            return category;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _AppDbContext.Categories.AddAsync(category);
            await _AppDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var _Category = await _AppDbContext.Categories.
                FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if (_Category != null)
            {
                _Category.Name = category.Name;
            }
            // _repositoryContext.Update(category);
            await _AppDbContext.SaveChangesAsync();
            return _Category;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _AppDbContext.Categories.
                Where(c => c.CategoryId == id).FirstOrDefaultAsync();
            _AppDbContext.Remove(category);
            await _AppDbContext.SaveChangesAsync();
            return category;
        }
        //public async Task<CategoryDto> DeleteCategoryDto(int id)
        //{
        //    var _category = new Category();

        //    _category = await _repositoryContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == _category.CategoryId);

        //    _repositoryContext.Remove(_category);
        //    await _repositoryContext.SaveChangesAsync();
        //    return _category;

    }
}
