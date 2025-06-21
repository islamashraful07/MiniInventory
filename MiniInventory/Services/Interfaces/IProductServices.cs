using MiniInventory.DTOs;
using MiniInventory.Models.Entities;
using NuGet.Protocol.Core.Types;

namespace MiniInventory.Services.Interfaces
{
    public interface IProductServices
    {
        Task<List<Models.ViewModels.ProductModel>> GetAllProductsAsync(SearchFilterDto searchFilter);
        Task<Models.ViewModels.ProductModel> GetProductByIdAsync(int id);
        Task AddProductAsync(Models.ViewModels.ProductModel product);
        Task UpdateProductAsync(Models.ViewModels.ProductModel product);
        Task DeleteProductAsync(int id);
    }
}
