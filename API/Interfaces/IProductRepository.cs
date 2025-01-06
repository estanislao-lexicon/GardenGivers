using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.Product;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryObject query);
        Task<Product?> GetByIdAsync(int productId);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int productId, UpdateProductRequestDto productDto);
        Task<Product?> DeleteAsync(int productId);
        Task<bool> ProductExist(int productId);
    }
}
