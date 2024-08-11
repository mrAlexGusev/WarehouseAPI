using System.ComponentModel.DataAnnotations;
using WarehouseAPI.DAL.Models.Abstract;

namespace WarehouseAPI.DAL.Models
{
    public class Product : NamedEntity
    {
        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
