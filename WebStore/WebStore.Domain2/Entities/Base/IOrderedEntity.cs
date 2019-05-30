namespace WebStore.Domain.Entities.Base
{
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
