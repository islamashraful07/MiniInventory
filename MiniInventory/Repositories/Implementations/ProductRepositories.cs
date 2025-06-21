using Microsoft.EntityFrameworkCore;
using MiniInventory.DTOs;
using MiniInventory.Models.Entities;
using MiniInventory.Repositories.Interfaces;

namespace MiniInventory.Repositories.Implementations
{
    public class ProductRepositories:IProductRepositories
    {
        private readonly Data.Datacontext _context;
        public ProductRepositories(Data.Datacontext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProductsAsync(SearchFilterDto searchFilter)
        {
            if(!string.IsNullOrEmpty(searchFilter.Name) || searchFilter.Category != 0)
            {
                return await _context.Products
                    .Where(p => p.Name.Contains(searchFilter.Name) || p.Category == searchFilter.Category).ToListAsync();
            }

            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
