using Curd.Model.Models;
using Curd.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [Authorize(Policy ="All")]
        [HttpGet]
        [Route("Categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var category = await _services.getCategory();
            return category;
        }

        [Authorize(Policy = "All")]
        [HttpGet]
        [Route("Category/{id}")]

        public async Task<Category> GetById(int id)
        {
            var category = await _services.getCategoryById(id);
            return category;
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Category")]
        public async Task<Category> CreateCategory(Category category)
        {
            var _category = await _services.CreateCategory(category);
            return _category;
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("Category/{id}")]
        public async Task<Category> UpdateCategory(Category category)
        {
            var _Category = await _services.UpdateCategory(category);
            return _Category;
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("Category/{id}")]
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _services.DeleteCategory(id);
            return category;
        }
    }
}

