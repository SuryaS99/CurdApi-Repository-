using Curd.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curd.Database.IRepository
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> getProduct();
        Task<Product> getProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
    }
}
