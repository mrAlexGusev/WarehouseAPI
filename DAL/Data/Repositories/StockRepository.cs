using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.DBContext;
using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.DAL.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task AddAsync(Stock entity)
        {
            await _context.Stocks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock entity)
        {
            _context.Stocks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
    }
}
