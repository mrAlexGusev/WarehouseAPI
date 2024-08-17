using System.ComponentModel.DataAnnotations;
using WarehouseAPI.DAL.Entities.Abstract;

namespace WarehouseAPI.DAL.Entities
{
    public class Warehouse : NamedEntity
    {
        [StringLength(200)]
        public string? Address { get; set; }

        [Phone]
        public string? ContactPhone { get; set; }
    }
}
