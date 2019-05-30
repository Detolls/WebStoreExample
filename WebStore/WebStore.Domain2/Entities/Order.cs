using System;
using System.Collections.ObjectModel;
using WebStore.Domain.Entities;

namespace WebStore.Domain
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order : NamedEntity
    {
        public virtual User User { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public virtual Collection<OrderItem> OrderItems { get; set; }
    }
}
