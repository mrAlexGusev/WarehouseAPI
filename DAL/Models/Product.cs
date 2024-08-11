using WarehouseAPI.DAL.Models.Abstract;

namespace WarehouseAPI.DAL.Models
{
    public class Product : NamedEntity
    {
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
