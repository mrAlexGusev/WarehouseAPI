using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.DBContext;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.DAL.Data.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _context.Warehouses.FindAsync(id);
        }

        public async Task AddAsync(Warehouse entity)
        {
            await _context.Warehouses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse entity)
        {
            _context.Warehouses.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
