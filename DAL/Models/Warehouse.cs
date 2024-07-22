using WarehouseAPI.DAL.Models.Abstract;

namespace WarehouseAPI.DAL.Models
{
    public class Warehouse : NamedEntity
    {
        public string Address { get; set; }
        public string ContactPhone { get; set; }
    }
}
