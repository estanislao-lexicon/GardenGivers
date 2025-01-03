using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Product;
using API.Helpers;


namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {
            return await _context.Products
                .Include(o => o.Objects)
                .Include(r => r.Requests)
                .ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int ProductId)
        {
            return await _context.Products
                .Include(o => o.Objects)
                .Include(r => r.Requests)
                .FirstOrDefaultAsync(i => i.ProductId == ProductId);
        }
        public async Task<Product> CreateAsync(Product ProductModel)
        {
            await _context.Products.AddAsync(ProductModel);
            await _context.SaveChangesAsync();
            return ProductModel;
        }

        public async Task<Product?> DeleteAsync (int ProductId)
        {
            var ProductModel = await _context.Products.FirstOrDefaultAsync(p => p.ProductId = ProductId);
            
            if(ProductModel == null)
            {
                return null;
            }

            _context.Products.Remove(ProductModel);
            await _context.SaveChangesAsync();
            return ProductModel;
        }

        public Task<bool> ProductExists(int ProductId)
        { 
            return _context.Product.AnyAsync(p => p.ProductId == ProductId);
        }
        public async Task<Product?> UpdateAsync (int productId, UpdateProductRequestDto productDto)
        {
            var existingProduct = await _context.Product.FindAsync(productId);

            if(existingProduct == null)
               return null;

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
