using System.ComponentModel.DataAnnotations;
using WarehouseAPI.DAL.Entities.Abstract;

namespace WarehouseAPI.DAL.Entities
{
    public class Stock : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
