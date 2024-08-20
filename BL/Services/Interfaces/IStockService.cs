using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.BL.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllAsync();
        Task<StockDTO> GetByIdAsync(int id);
        Task AddAsync(StockDTO entity);
        Task UpdateAsync(StockDTO entity);
        Task DeleteAsync(int id);
    }
}
