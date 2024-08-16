using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.BL.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(int id);
        Task AddAsync(Stock entity);
        Task UpdateAsync(Stock entity);
        Task DeleteAsync(int id);
    }
}
