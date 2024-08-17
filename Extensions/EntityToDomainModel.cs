using WarehouseAPI.BL.Domain;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.Extensions
{
    public static class EntityToDomainModel
    {
        public static ProductDTO ToDomainModel(this Product entity)
        {
            return new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Unit = entity.Unit,
                Price = entity.Price
            };
        }

        public static StockDTO ToDomainModel(this Stock entity)
        {
            return new StockDTO
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                WarehouseId = entity.WarehouseId,
                Quantity = entity.Quantity,
                LastUpdated = entity.LastUpdated,
                Product = entity.Product?.ToDomainModel(),
                Warehouse = entity.Warehouse?.ToDomainModel()
            };
        }

        public static WarehouseDTO ToDomainModel(this Warehouse entity)
        {
            return new WarehouseDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                ContactPhone = entity.ContactPhone
            };
        }
    }
}
