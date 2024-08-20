using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.Extensions;

namespace WarehouseAPI.BL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockDTO>> GetAllAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return stocks.Select(s => s.ToDomainModel());
        }

        public async Task<StockDTO> GetByIdAsync(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            return stock?.ToDomainModel();
        }

        public async Task AddAsync(StockDTO stockDTO)
        {
            var stock = stockDTO.ToEntity();
            await _stockRepository.AddAsync(stock);
        }

        public async Task UpdateAsync(StockDTO stockDTO)
        {
            var stock = stockDTO.ToEntity();
            await _stockRepository.UpdateAsync(stock);
        }

        public async Task DeleteAsync(int id)
        {
            await _stockRepository.DeleteAsync(id);
        }
    }
}
