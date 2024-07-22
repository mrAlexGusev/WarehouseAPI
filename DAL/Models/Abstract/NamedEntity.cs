namespace WarehouseAPI.DAL.Models.Abstract
{
    public class NamedEntity : IBaseEntity, INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
