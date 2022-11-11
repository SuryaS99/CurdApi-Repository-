using Curd.Database.IRepository;
using Curd.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Products
{
   public class ProductsServices:IProductsServices
    {
        private readonly IProductsRepository _product;

        public ProductsServices(IProductsRepository product)
        {
           _product = product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var products = await _product.CreateProduct(product);
            return products;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _product.DeleteProduct(id);
            return product;
        }

        public async Task<IEnumerable<Product>> getProduct()
        {
            var product = await _product.getProduct();
            return product;
        }

        public async Task<Product> getProductById(int id)
        {
            var product = await _product.getProductById(id);
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var products = await _product.UpdateProduct(product);
            return products;
        }
    }
}
