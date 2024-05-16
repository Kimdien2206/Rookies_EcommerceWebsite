using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests
{
    public class ProductRepositoryTesting
    {
        private readonly Mock<ApplicationDbContext> _mockObject;
        private readonly ProductRepository _productRepository;

        private readonly List<Product> _products = new List<Product>()
        {
            new Product()
            {
                Id = "1",
                Name = "Test",
                Description = "Test",
                Images = ["test1", "test2"],
                Slug = "Test",
                Price = 20000,
                IsDeleted = true,
            },
            new Product()
            {
                Id = "2",
                Name = "Test2",
                Description = "Test2",
                Images = ["test1", "test2"],
                Slug = "Test",
                Price = 20000,
                IsDeleted = true,
            }
        };
        public ProductRepositoryTesting() 
        {
            var mockSet = new Mock<DbSet<Product>>();
            mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(_products.AsQueryable().Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(_products.AsQueryable().Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(_products.AsQueryable().ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(_products.GetEnumerator());

            
            _mockObject = new Mock<ApplicationDbContext>();
            _mockObject.Setup(m => m.Products).Returns(mockSet.Object);
            _productRepository = new ProductRepository(_mockObject.Object);
        }

        [Fact]
        public async void GetAll_ReturningType_ListProduct()
        {
            var products = await _productRepository.GetAll();

            Assert.Equal(products, _products);
        }

        //[Fact]
        //public async void Create_CountIncreaseBy1()
        //{
        //    int count = _products.Count();
        //    await _productRepository.Create(new Product() 
        //    {
        //        Id = "1",
        //        Name = "Test",
        //        Description = "Test",
        //        Images = ["test1", "test2"],
        //        Slug = "Test",
        //        Price = 20000,
        //        IsDeleted = true,
        //    });


        //    Assert.Equal(count+1, _products.Count());
        //}
    }
}
