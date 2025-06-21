using AutoMapper;
using MiniInventory.DTOs;
using MiniInventory.Models.Entities;
using MiniInventory.Services.Interfaces;
using NuGet.Protocol.Core.Types;

namespace MiniInventory.Services.Implementations
{
    public class ProductServices:IProductServices
    {
        private readonly Repositories.Interfaces.IProductRepositories _productRepositories;
        private readonly IMapper _customDtoMapper;
        public ProductServices(Repositories.Interfaces.IProductRepositories productRepositories,IMapper customDtoMapper)
        {
            _productRepositories = productRepositories;
            _customDtoMapper = customDtoMapper;
        }
        public async Task<List<Models.ViewModels.ProductModel>> GetAllProductsAsync(SearchFilterDto searchFilter)
        {
            var productData= await _productRepositories.GetAllProductsAsync( searchFilter);
            return _customDtoMapper.Map<List<Models.ViewModels.ProductModel>>(productData);
        }
        public async Task<Models.ViewModels.ProductModel> GetProductByIdAsync(int id)
        {
            var product= await _productRepositories.GetProductByIdAsync(id);
            return _customDtoMapper.Map<Models.ViewModels.ProductModel>(product);
        }
        public async Task AddProductAsync(Models.ViewModels.ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var productEntity = _customDtoMapper.Map<Models.Entities.Product>(product);
            await _productRepositories.AddProductAsync(productEntity);
        }
        public async Task UpdateProductAsync(Models.ViewModels.ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            var productEntity = _customDtoMapper.Map<Models.Entities.Product>(product);
            await _productRepositories.UpdateProductAsync(productEntity);
        }
        public async Task DeleteProductAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID", nameof(id));
            await _productRepositories.DeleteProductAsync(id);
        }
    }
}
