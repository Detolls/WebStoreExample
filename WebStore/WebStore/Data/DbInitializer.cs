using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Infrastructure.Implementations;

namespace WebStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebStoreContext context)
        {
            context.Database.EnsureCreated();
            //Look for any products.
            if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

            InMemoryProductData productData = new InMemoryProductData();

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in productData.GetSections())
                {
                    context.Sections.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var brand in productData.GetBrands())
                {
                    context.Brands.Add(brand);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var product in productData.GetProducts())
                {
                    context.Products.Add(product);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");
                trans.Commit();
            }

        }
    }
}