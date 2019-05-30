using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Filters;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Product;

namespace WebStore.Controllers
{
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly IProductData productData;

        public ShopController(IProductData productData)
        {
            this.productData = productData;
        }

        /// <summary>
        /// List of products
        /// </summary>
        /// <param name="sectionID"></param>
        /// <param name="brandID"></param>
        /// <returns></returns>
        [Route("products/{id?}")]
        public IActionResult Products(int? sectionID, int? brandID)
        {
            var products = productData.GetProducts(new ProductFilter { BrandID = brandID, SectionID = sectionID });

            var catalog = new CatalogViewModel()
            {
                BrandID = brandID,
                SectionID = sectionID,
                Products = products.Select(p => new ProductViewModel
                {
                    ID = p.ID,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    Brand = p.Brand?.Name ?? string.Empty
                }).OrderBy(p => p.Order).ToList()
            };

            return View(catalog);
        }

        /// <summary>
        /// Product details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("product_details")]
        public IActionResult ProductDetails(int id)
        {
            var product = productData.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(new ProductViewModel
                {
                    ID = product.ID,
                    ImageUrl = product.ImageUrl,
                    Name = product.Name,
                    Order= product.Order,
                    Price = product.Price,
                    Brand = product.Brand?.Name ?? string.Empty
                });
            }
        }
    }
}