using WarehouseAPI.BL.Domain;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.Extensions
{
    public static class DomainModelToEntity
    {
        public static Product ToEntity(this ProductDTO domainModel)
        {
            return new Product
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Description = domainModel.Description,
                Quantity = domainModel.Quantity,
                Unit = domainModel.Unit,
                Price = domainModel.Price
            };
        }

        public static Stock ToEntity(this StockDTO domainModel)
        {
            return new Stock
            {
                Id = domainModel.Id,
                ProductId = domainModel.ProductId,
                WarehouseId = domainModel.WarehouseId,
                Quantity = domainModel.Quantity,
                LastUpdated = domainModel.LastUpdated,
                Product = domainModel.Product?.ToEntity(),
                Warehouse = domainModel.Warehouse?.ToEntity()
            };
        }

        public static Warehouse ToEntity(this WarehouseDTO domainModel)
        {
            return new Warehouse
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Address = domainModel.Address,
                ContactPhone = domainModel.ContactPhone
            };
        }
    }
}
