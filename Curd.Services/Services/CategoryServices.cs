using Curd.Model.Models;
using Curd.Database.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _category;

        public CategoryServices(ICategoryRepository category)
        {
            _category = category;
        }

        public async Task<IEnumerable<Category>> getCategory()
        {
            var cat = await _category.getCategory();
            return cat;
        }

        public async Task<Category> getCategoryById(int id)
        {
            var category = await _category.getCategoryById(id);
            if(category != null)
            {
                return (Category)category;
            }
            return null;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            var categor = await _category.CreateCategory(category);
            return categor;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            var categor = await _category.UpdateCategory(category);
            return categor;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _category.DeleteCategory(id);
            return category;
        }
        //public async Task<CategoryDto> DeleteCategoryDto(int id)
        //{
        //    var _Category = await _category.DeleteCategoryDto(id);
        //    return _Category;
        //}
    }
}
