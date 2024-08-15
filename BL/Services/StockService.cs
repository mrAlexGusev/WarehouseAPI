using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.BL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _stockRepository.GetAllAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _stockRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Stock entity)
        {
            await _stockRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Stock entity)
        {
            await _stockRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _stockRepository.DeleteAsync(id);
        }
    }
}
