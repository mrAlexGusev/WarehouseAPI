using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.DAL.Entities.Abstract
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
