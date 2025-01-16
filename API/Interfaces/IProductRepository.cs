using API.Models;
using API.Helpers;
using API.Dtos.Product;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryObject query);
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetByNameAsync(string productName);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int productId, UpdateProductDto productDto);
        Task<Product?> DeleteAsync(int productId);
        Task<bool> ProductExist(int productId);
    }
}
