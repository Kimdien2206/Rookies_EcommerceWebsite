using Rookies_EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.MockData
{
    public static class MockCart
    {
        private static List<Cart> MockData = new List<Cart>()
        {
            new Cart()
            {
                Id = "1",
                VariantId = "1",
                CustomerId = "1",
                TotalCost = 900000,
                Amount = 1,
                Variant = new Variant()
                {
                    Id = "1",
                    Name = "Test1",
                    Stock = 12,
                    ProductId = "1",
                }
            },
            new Cart()
            {
                Id = "2",
                VariantId = "2",
                CustomerId = "3",
                TotalCost = 900000,
                Amount = 1,
                Variant = new Variant()
                {
                    Id = "2",
                    Name = "Test2",
                    Stock = 12,
                    ProductId = "1"
                }
            },
            new Cart()
            {
                Id = "3",
                VariantId = "3",
                CustomerId = "2",
                TotalCost = 900000,
                Amount = 1,
                Variant = new Variant()
                {
                    Id = "3",
                    Name = "Test3",
                    Stock = 12,
                    ProductId = "2"
                }
            },
            new Cart()
            {
                Id = "4",
                VariantId = "4",
                CustomerId = "2",
                TotalCost = 900000,
                Amount = 1,
                Variant = new Variant()
                {
                    Id = "4",
                    Name = "Test4",
                    Stock = 12,
                    ProductId = "1"
                }
            },
        };


        public static List<Cart> GetCarts()
        {
            return MockData;
        }

        public static Cart Add(Cart cart)
        {
            MockData.Add(cart);
            return cart;
        }
    }
}
