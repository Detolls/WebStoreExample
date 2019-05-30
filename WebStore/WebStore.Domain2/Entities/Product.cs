using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain
{
    /// <summary>
    /// Product entity
    /// </summary>
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int SectionID { get; set; }

        [ForeignKey("SectionID")]
        public virtual Section Section { get; set; }

        public int? BrandID { get; set; }

        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }

}
