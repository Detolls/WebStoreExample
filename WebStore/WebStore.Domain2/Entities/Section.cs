using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain
{
    /// <summary>
    /// Section entity
    /// </summary>
    [Table("Sections")]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public virtual Section ParentSection { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

}
