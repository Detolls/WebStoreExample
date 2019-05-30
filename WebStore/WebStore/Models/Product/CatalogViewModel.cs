using System.Collections.Generic;

namespace WebStore.Models.Product
{
    public class CatalogViewModel
    {
        public int? BrandID { get; set; }
        public int? SectionID { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
