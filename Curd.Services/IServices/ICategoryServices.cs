using System;
using Curd.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Categories
{
    public interface ICategoryServices
    {


        Task<IEnumerable<Category>> getCategory();
        Task<Category> getCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        // Task<Category> UpdateCategory(Category category, int id);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);
       // Task<CategoryDto> DeleteCategoryDto(int id);
    }
}
