using Dtos;
using Rookies_EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.MockData
{
    public static class MockVariant
    {
        private static List<Variant> MockData = new List<Variant>()
        {
            new Variant()
            {
                Id = "1",
                Name = "Test1",
                Stock = 12,
                ProductId = "1"
            },
            new Variant()
            {
                Id = "2",
                Name = "Test2",
                Stock = 12,
                ProductId = "1"
            },
            new Variant()
            {
                Id = "3",
                Name = "Test3",
                Stock = 12,
                ProductId = "2"
            },
            new Variant()
            {
                Id = "4",
                Name = "Test4",
                Stock = 12,
                ProductId = "1"
            },
        };


        public static List<Variant> GetVariants()
        {
            return MockData;
        }

        public static Variant Add(Variant product)
        {
            MockData.Add(product);
            return product;
        }
    }
}
