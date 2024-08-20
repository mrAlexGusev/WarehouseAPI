using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.BL.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDTO>> GetAllAsync();
        Task<WarehouseDTO> GetByIdAsync(int id);
        Task AddAsync(WarehouseDTO entity);
        Task UpdateAsync(WarehouseDTO entity);
        Task DeleteAsync(int id);
    }
}
