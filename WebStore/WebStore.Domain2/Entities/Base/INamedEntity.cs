namespace WebStore.Domain.Entities.Base
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
