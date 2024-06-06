using Dtos;
using Rookies_EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.MockData
{
    public static class MockProduct
    {
        private static List<Product> MockData = new List<Product>()
        {
            new Product()
            {
                Id = "1",
                Name = "Test",
                Description = "Test",
                Images = ["test1", "test2"],
                Slug = "Test-1",
                Price = 20000,
                IsDeleted = true,
            },
            new Product()
            {
                Id = "2",
                Name = "Test2",
                Description = "Test2",
                Images = ["test1", "test2"],
                Slug = "Test-2",
                Price = 20000,
                IsDeleted = true,
            }
        };


        public static List<Product> GetProducts()
        {
            return MockData;
        }

        public static Product Add(Product product)
        {
            MockData.Add(product);
            return product;
        }
    }
}
