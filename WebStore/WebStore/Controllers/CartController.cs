using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Cart;
using WebStore.Models.Order;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IOrdersService ordersService;

        public CartController(ICartService cartService, IOrdersService ordersService)
        {
            this.cartService = cartService;
            this.ordersService = ordersService;
        }

        /// <summary>
        /// Cart details
        /// </summary>
        /// <returns></returns>
        public IActionResult Details()
        {
            var model = new DetailsViewModel()
            {
                CartViewModel = cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };

            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Checkout order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderResult = ordersService.CreateOrder(model, cartService.TransformCart(), User.Identity.Name);
                cartService.RemoveAll();

                return RedirectToAction("OrderConfirmed", new { id = orderResult.ID });
            }

            var detailsModel = new DetailsViewModel()
            {
                CartViewModel = cartService.TransformCart(),
                OrderViewModel = model
            };

            return View("Details", detailsModel);
        }

        /// <summary>
        ///  Order confirmation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

    }
}