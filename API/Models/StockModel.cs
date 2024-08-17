namespace WarehouseAPI.API.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public ProductModel Product { get; set; }
        public WarehouseModel Warehouse { get; set; }
    }
}
