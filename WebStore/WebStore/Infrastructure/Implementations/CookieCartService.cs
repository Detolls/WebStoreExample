using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain;
using WebStore.Filters;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Product;

namespace WebStore.Infrastructure.Implementations
{
    public class CookieCartService : ICartService
    {
        private readonly IProductData productData;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string cartName;

        private Cart Cart
        {
            get
            {
                var cookie = httpContextAccessor
                                .HttpContext
                                .Request
                                .Cookies[cartName];
                string json = string.Empty;
                Cart cart = null;

                if (cookie == null)
                {
                    cart = new Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);

                    httpContextAccessor
                          .HttpContext
                          .Response
                          .Cookies
                          .Append(
                             cartName,
                             json,
                             new CookieOptions()
                             {
                                 Expires = DateTime.Now.AddDays(1)
                             });
                    return cart;
                }

                json = cookie;
                cart = JsonConvert.DeserializeObject<Cart>(json);

                httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Delete(cartName);

                httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Append(
                          cartName,
                          json,
                          new CookieOptions()
                          {
                              Expires = DateTime.Now.AddDays(1)
                          });

                return cart;
            }

            set
            {
                var json = JsonConvert.SerializeObject(value);

                httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Delete(cartName);
                httpContextAccessor
                      .HttpContext
                      .Response
                      .Cookies
                      .Append(
                           cartName,
                           json,
                           new CookieOptions()
                           {
                               Expires = DateTime.Now.AddDays(1)
                           });
            }
        }

        public CookieCartService(IProductData productData, IHttpContextAccessor httpContextAccessor)
        {
            this.productData = productData;
            this.httpContextAccessor = httpContextAccessor;
            cartName = "cart" + (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? httpContextAccessor.HttpContext.User.Identity.Name : "");
        }

        /// <summary>
        /// Decrement from cart
        /// </summary>
        /// <param name="id"></param>
        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductID == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                    item.Quantity--;

                if (item.Quantity == 0)
                    cart.Items.Remove(item);
            }

            Cart = cart;
        }

        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <param name="id"></param>
        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductID == id);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            Cart = cart;
        }

        /// <summary>
        /// Remove all items from cart
        /// </summary>
        public void RemoveAll()
        {
            Cart = new Cart { Items = new List<CartItem>() };
        }

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="id"></param>
        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductID == id);

            if (item != null)
                item.Quantity++;
            else
                cart.Items.Add(new CartItem { ProductID = id, Quantity = 1 });

            Cart = cart;
        }

        /// <summary>
        /// Transform cart
        /// </summary>
        /// <returns></returns>
        public CartViewModel TransformCart()
        {
            var products = productData.GetProducts(new ProductFilter()
            {
                Ids = Cart.Items.Select(i => i.ProductID).ToList()
            }).Select(p => new ProductViewModel()
            {
                ID = p.ID,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var r = new CartViewModel
            {
                Items = Cart.Items.ToDictionary(
                            x => products.First(y => y.ID == x.ProductID),
                            x => x.Quantity)
            };

            return r;
        }

    }
}
