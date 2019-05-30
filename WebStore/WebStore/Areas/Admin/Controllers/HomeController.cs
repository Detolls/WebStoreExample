using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly IProductData productData;

        public HomeController(IProductData productData)
        {
            this.productData = productData;
        }

        /// <summary>
        /// Admin home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Product list
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductList()
        {
            var products = productData.GetProducts(new ProductFilter());

            return View(products);
        }
    }
}