using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
