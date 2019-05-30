using WebStore.Domain.Entities.Base;

namespace WebStore.Models.Product
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductsCount { get; set; }
        public int Order { get; set; }
    }
}
