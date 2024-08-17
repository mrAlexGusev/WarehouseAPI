using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.BL.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _warehouseRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Warehouse entity)
        {
            await _warehouseRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Warehouse entity)
        {
            await _warehouseRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _warehouseRepository.DeleteAsync(id);
        }
    }
}
