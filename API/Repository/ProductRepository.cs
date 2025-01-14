using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Product;
using API.Helpers;


namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync(ProductQueryObject query)
        {
            var products = _context.Products
                .Include(o => o.Offers)                
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.ProductName))
            {
                products = products.Where(p => p.ProductName.Contains(query.ProductName));
            }

            return await products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.Products
                .Include(o => o.Offers)                
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<List<Product>> GetByNameAsync(string productName)
        {
            return await _context.Products
                .Where(p => p.ProductName.ToLower().Contains(productName.ToLower()))
                .Include(o => o.Offers)
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync (int productId)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            
            if(productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public Task<bool> ProductExist(int productId)
        { 
            return _context.Products.AnyAsync(p => p.ProductId == productId);
        }
        
        public async Task<Product?> UpdateAsync (int productId, UpdateProductRequestDto productDto)
        {
            var existingProduct = await _context.Products.FindAsync(productId);

            if(existingProduct == null)
               return null;

            existingProduct.ProductName = productDto.ProductName;
            existingProduct.ProductDescription = productDto.ProductDescription;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
