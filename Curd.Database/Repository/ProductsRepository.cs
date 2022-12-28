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
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(AppDbContext AppDbContext) : base(AppDbContext)
        {

        }
        public async Task<IEnumerable<Product>> getProduct()
        {
            var product = await (from p in _AppDbContext.Products
                                 select p).ToListAsync();
            return product;
        }
        public async Task<Product> getProductById(int id)
        {
            var product = await _AppDbContext.Products.
                Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return product;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _AppDbContext.Products.AddAsync(product);
            await _AppDbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var _product = await _AppDbContext.Products.
                FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.CategoryId = product.CategoryId;
            }
            // _repositoryContext.Update(product);
            await _AppDbContext.SaveChangesAsync();
            return _product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _AppDbContext.Products.
                Where(p => p.ProductId == id).FirstOrDefaultAsync();
            _AppDbContext.Remove(product);
            await _AppDbContext.SaveChangesAsync();
            return product;
        }

    }
}
