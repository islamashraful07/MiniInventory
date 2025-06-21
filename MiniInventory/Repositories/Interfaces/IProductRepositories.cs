using MiniInventory.DTOs;
using MiniInventory.Models.Entities;
using NuGet.Protocol.Core.Types;

namespace MiniInventory.Repositories.Interfaces
{
    public interface IProductRepositories
    {
        Task<List<Models.Entities.Product>> GetAllProductsAsync(SearchFilterDto searchFilter );
        Task<Models.Entities.Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Models.Entities.Product product);
        Task UpdateProductAsync(Models.Entities.Product product);
        Task DeleteProductAsync(int id);
    }
}
