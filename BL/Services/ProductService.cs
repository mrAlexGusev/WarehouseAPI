using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.Extensions;

namespace WarehouseAPI.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => p.ToDomainModel());
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product?.ToDomainModel();
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var product = productDTO.ToEntity();
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var product = productDTO.ToEntity();
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
