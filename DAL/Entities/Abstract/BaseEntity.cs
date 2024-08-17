using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.DAL.Entities.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
