using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.BL.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
        Task AddAsync(Warehouse entity);
        Task UpdateAsync(Warehouse entity);
        Task DeleteAsync(int id);
    }
}
