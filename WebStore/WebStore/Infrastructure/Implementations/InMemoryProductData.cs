using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain;
using WebStore.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryProductData : IProductData
    {
        private readonly List<Section> sections;
        private readonly List<Brand> brands;
        private readonly List<Product> products;

        public InMemoryProductData()
        {
            sections = new List<Section>()
            {
                new Section()
                {
                    ID = 1,
                    Name = "Sportswear",
                    Order = 0,
                    ParentID = null
                },
                new Section()
                {
                    ID = 2,
                    Name = "Nike",
                    Order = 0,
                    ParentID = 1
                },
                new Section()
                {
                    ID = 3,
                    Name = "Under Armour",
                    Order = 1,
                    ParentID = 1
                },
                new Section()
                {
                    ID = 4,
                    Name = "Adidas",
                    Order = 2,
                    ParentID = 1
                },
                new Section()
                {
                    ID = 5,
                    Name = "Puma",
                    Order = 3,
                    ParentID = 1
                },
                new Section()
                {
                    ID = 6,
                    Name = "ASICS",
                    Order = 4,
                    ParentID = 1
                },
                new Section()
                {
                    ID = 7,
                    Name = "Mens",
                    Order = 1,
                    ParentID = null
                },
                new Section()
                {
                    ID = 8,
                    Name = "Fendi",
                    Order = 0,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 9,
                    Name = "Guess",
                    Order = 1,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 10,
                    Name = "Valentino",
                    Order = 2,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 11,
                    Name = "Dior",
                    Order = 3,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 12,
                    Name = "Versace",
                    Order = 4,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 13,
                    Name = "Armani",
                    Order = 5,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 14,
                    Name = "Prada",
                    Order = 6,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 15,
                    Name = "Dolce and Gabbana",
                    Order = 7,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 16,
                    Name = "Chanel",
                    Order = 8,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 17,
                    Name = "Gucci",
                    Order = 1,
                    ParentID = 7
                },
                new Section()
                {
                    ID = 18,
                    Name = "Womens",
                    Order = 2,
                    ParentID = null
                },
                new Section()
                {
                    ID = 19,
                    Name = "Fendi",
                    Order = 0,
                    ParentID = 18
                },
                new Section()
                {
                    ID = 20,
                    Name = "Guess",
                    Order = 1,
                    ParentID = 18
                },
                new Section()
                {
                    ID = 21,
                    Name = "Valentino",
                    Order = 2,
                    ParentID = 18
                },
                new Section()
                {
                    ID = 22,
                    Name = "Dior",
                    Order = 3,
                    ParentID = 18
                },
                new Section()
                {
                    ID = 23,
                    Name = "Versace",
                    Order = 4,
                    ParentID = 18
                },
                new Section()
                {
                    ID = 24,
                    Name = "Kids",
                    Order = 3,
                    ParentID = null
                },
                new Section()
                {
                    ID = 25,
                    Name = "Fashion",
                    Order = 4,
                    ParentID = null
                },
                new Section()
                {
                    ID = 26,
                    Name = "Households",
                    Order = 5,
                    ParentID = null
                },
                new Section()
                {
                    ID = 27,
                    Name = "Interiors",
                    Order = 6,
                    ParentID = null
                },
                new Section()
                {
                    ID = 28,
                    Name = "Clothing",
                    Order = 7,
                    ParentID = null
                },
                new Section()
                {
                    ID = 29,
                    Name = "Bags",
                    Order = 8,
                    ParentID = null
                },
                new Section()
                {
                    ID = 30,
                    Name = "Shoes",
                    Order = 9,
                    ParentID = null
                }
            };

            brands = new List<Brand>()
            {
                new Brand()
                {
                    ID = 1,
                    Name = "Acne",
                    Order = 0
                },
                new Brand()
                {
                    ID = 2,
                    Name = "Grüne Erde",
                    Order = 1
                },
                new Brand()
                {
                    ID = 3,
                    Name = "Albiro",
                    Order = 2
                },
                new Brand()
                {
                    ID = 4,
                    Name = "Ronhill",
                    Order = 3
                },
                new Brand()
                {
                    ID = 5,
                    Name = "Oddmolly",
                    Order = 4
                },
                new Brand()
                {
                    ID = 6,
                    Name = "Boudestijn",
                    Order = 5
                },
                new Brand()
                {
                    ID = 7,
                    Name = "Rösch creative culture",
                    Order = 6
                },
            };

            products = new List<Product>()
            {
                new Product()
                {
                    ID = 1,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product9.jpg",
                    Order = 0,
                    SectionID = 2,
                    BrandID = 1
                },
                new Product()
                {
                    ID = 2,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product8.jpg",
                    Order = 1,
                    SectionID = 2,
                    BrandID = 1
                },
                new Product()
                {
                    ID = 3,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product7.jpg",
                    Order = 2,
                    SectionID = 2,
                    BrandID = 1
                },
                new Product()
                {
                    ID = 4,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product10.jpg",
                    Order = 3,
                    SectionID = 2,
                    BrandID = 1
                },
                new Product()
                {
                    ID = 5,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product11.jpg",
                    Order = 4,
                    SectionID = 2,
                    BrandID = 2
                },
                new Product()
                {
                    ID = 6,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product12.jpg",
                    Order = 5,
                    SectionID = 2,
                    BrandID = 2
                },
                new Product()
                {
                    ID = 7,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product7.jpg",
                    Order = 6,
                    SectionID = 2,
                    BrandID = 2
                },
                new Product()
                {
                    ID = 8,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product8.jpg",
                    Order = 7,
                    SectionID = 25,
                    BrandID = 2
                },
                new Product()
                {
                    ID = 9,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product9.jpg",
                    Order = 8,
                    SectionID = 25,
                    BrandID = 2
                },
                new Product()
                {
                    ID = 10,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product10.jpg",
                    Order = 9,
                    SectionID = 25,
                    BrandID = 3
                },
                new Product()
                {
                    ID = 11,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product11.jpg",
                    Order = 10,
                    SectionID = 25,
                    BrandID = 3
                },
                new Product()
                {
                    ID = 12,
                    Name = "Easy Polo Black Edition",
                    Price = 25,
                    ImageUrl = "product12.jpg",
                    Order = 11,
                    SectionID = 25,
                    BrandID = 3
                },
            };
        }

        /// <summary>
        /// Get product sections
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Section> GetSections()
        {
            return sections;
        }

        /// <summary>
        /// Get product brands
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Brand> GetBrands()
        {
            return brands;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var _products = products;

            if (filter.SectionID.HasValue)
                _products = _products.Where(p => p.SectionID.Equals(filter.SectionID)).ToList();

            if (filter.BrandID.HasValue)
                _products = _products.Where(p => p.BrandID.HasValue && p.BrandID.Value.Equals(filter.BrandID.Value)).ToList();

            return _products;
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
