using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Product;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData productData;

        public BrandsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }

        /// <summary>
        /// Invoke component
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        /// <summary>
        /// Get brands
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BrandViewModel> GetBrands()
        {
            var dbBrands = productData.GetBrands();

            return dbBrands.Select(b => new BrandViewModel
            {
                ID = b.ID,
                Name = b.Name,
                Order = b.Order,
                ProductsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }
    }
}
