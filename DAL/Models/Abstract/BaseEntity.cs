using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.DAL.Models.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
