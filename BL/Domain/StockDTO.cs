namespace WarehouseAPI.BL.Domain
{
    public class StockDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public ProductDTO Product { get; set; }
        public WarehouseDTO Warehouse { get; set; }
    }
}
