using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.BL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task AddAsync(ProductDTO entity);
        Task UpdateAsync(ProductDTO entity);
        Task DeleteAsync(int id);
    }
}
