using System.Collections.Generic;

namespace WebStore.Filters
{
    public class ProductFilter
    {
        public List<int> Ids { get; set; }
        public int? SectionID { get; set; }
        public int? BrandID { get; set; }
    }
}
