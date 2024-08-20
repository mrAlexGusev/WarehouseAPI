using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.Extensions;

namespace WarehouseAPI.BL.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<WarehouseDTO>> GetAllAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();
            return warehouses.Select(w => w.ToDomainModel());
        }

        public async Task<WarehouseDTO> GetByIdAsync(int id)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id);
            return warehouse?.ToDomainModel();
        }

        public async Task AddAsync(WarehouseDTO warehouseDTO)
        {
            var warehouse = warehouseDTO.ToEntity();
            await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task UpdateAsync(WarehouseDTO warehouseDTO)
        {
            var warehouse = warehouseDTO.ToEntity();
            await _warehouseRepository.UpdateAsync(warehouse);
        }

        public async Task DeleteAsync(int id)
        {
            await _warehouseRepository.DeleteAsync(id);
        }
    }
}
