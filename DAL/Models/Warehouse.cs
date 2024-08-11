using System.ComponentModel.DataAnnotations;
using WarehouseAPI.DAL.Models.Abstract;

namespace WarehouseAPI.DAL.Models
{
    public class Warehouse : NamedEntity
    {
        [StringLength(200)]
        public string? Address { get; set; }

        [Phone]
        public string? ContactPhone { get; set; }
    }
}
