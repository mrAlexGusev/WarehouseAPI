using WarehouseAPI.DAL.Models.Abstract;

namespace WarehouseAPI.DAL.Models
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
