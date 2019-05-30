using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain
{
    /// <summary>
    /// Brand entity
    /// </summary>
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// List products
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }

}
