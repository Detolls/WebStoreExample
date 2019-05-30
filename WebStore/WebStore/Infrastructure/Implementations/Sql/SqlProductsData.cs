using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain;
using WebStore.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext context;

        public SqlProductData(WebStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Section> GetSections()
        {
            return context.Sections.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return context.Brands.ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = context.Products.Include(p => p.Brand).Include(p => p.Section).AsQueryable();

            if (filter.BrandID.HasValue)
                query = query.Where(c => c.BrandID.HasValue && c.BrandID == filter.BrandID);

            if (filter.SectionID.HasValue)
                query = query.Where(c => c.SectionID == filter.SectionID);

            return query.ToList();
        }

        public Product GetProductByID(int id)
        {
            return context.Products.Include(p => p.Brand).Include(p => p.Section).FirstOrDefault(p => p.ID == id);
        }

    }
}
