using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Filters;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        Product GetProductByID(int id);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(ProductFilter filter); 
    }
}
