using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _productRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
