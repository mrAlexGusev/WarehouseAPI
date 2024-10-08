﻿using WarehouseAPI.DAL.Entities.Abstract;

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
}
