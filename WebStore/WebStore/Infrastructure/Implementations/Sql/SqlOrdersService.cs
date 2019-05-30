using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Order;
using WebStore.Models.Product;

namespace WebStore.Infrastructure.Implementations.Sql
{
    public class SqlOrdersService : IOrdersService
    {
        private readonly WebStoreContext context;
        private readonly UserManager<User> userManager;

        public SqlOrdersService(WebStoreContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            return context.Orders.Include("User").Include("OrderItems").Where(o => o.User.UserName == userName).ToList();
        }

        public Order GetOrderByID(int id)
        {
            return context.Orders.Include("OrderItems").FirstOrDefault(o => o.ID == id);
        }

        public Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;

            using (var transaction = context.Database.BeginTransaction())
            {
                var order = new Order()
                {
                    Address = orderModel.Address,
                    Name = orderModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.Phone,
                    User = user
                };

                context.Orders.Add(order);

                foreach (var item in transformCart.Items)
                {
                    var productVm = item.Key;
                    var product = context.Products.FirstOrDefault(p => p.ID == productVm.ID);

                    if (product == null)
                        throw new InvalidOperationException("Product was not found in the database");

                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Value,
                        Product = product
                    };

                    context.OrderItems.Add(orderItem);
                }

                context.SaveChanges();
                transaction.Commit();
                return order;
            }
        }

    }
}
