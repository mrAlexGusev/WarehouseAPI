using WarehouseAPI.DAL.Models.Abstract;
using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.DAL.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IProductRepository : IRepository<Product>
    {
        // Дополнительные методы для Product, если необходимо
    }

    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        // Дополнительные методы для Warehouse, если необходимо
    }

    public interface IStockRepository : IRepository<Stock>
    {
        // Дополнительные методы для Stock, если необходимо
    }
}
