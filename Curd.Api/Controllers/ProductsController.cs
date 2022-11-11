using Curd.Model.Models;
using Curd.Services.Products;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _services;

        public ProductsController(IProductsServices services)
        {
            _services = services;
        }

        [Authorize(Policy = "All")]
        [HttpGet]
        [Route("Products")]
        public async Task<IEnumerable<Product>> getProduct()
        {
            var product = await _services.getProduct();
            return product;
        }

        [Authorize(Policy = "All")]
        [HttpGet]
        [Route("Product/{id}")]
        public async Task<Product> getProductById(int id)
        {
            var product = await _services.getProductById(id);
            return product;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Product")]
        public async Task<Product> CreateProduct(Product product)
        {
            var _product = await _services.CreateProduct(product);
            return _product;
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("Product/{id}")]
        public async Task<Product> UpdateProduct(Product product)
        {
            var _product = await _services.UpdateProduct(product);
            return _product;
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("Product/{id}")]
        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _services.DeleteProduct(id);
            return product;
        }
    }
}
