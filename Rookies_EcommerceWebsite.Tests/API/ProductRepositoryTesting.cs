using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using Rookies_EcommerceWebsite.Tests.API.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.API
{
    public class ProductRepositoryTesting
    {
        private readonly Mock<ApplicationDbContext> _mockObject;
        private readonly ProductRepository _productRepository;


        public ProductRepositoryTesting()
        {
            var mockSet = new Mock<DbSet<Product>>();
            mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(MockProduct.GetProducts().AsQueryable().Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(MockProduct.GetProducts().AsQueryable().Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(MockProduct.GetProducts().AsQueryable().ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(MockProduct.GetProducts().GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Product>())).Callback<Product>((s) => MockProduct.Add(s));


            _mockObject = new Mock<ApplicationDbContext>();
            _mockObject.Setup(m => m.Products).Returns(mockSet.Object);
            _productRepository = new ProductRepository(_mockObject.Object);
        }

        [Fact]
        public async void GetAll_ReturningType_ListProduct()
        {
            var products = await _productRepository.GetAll();

            Assert.Equal(products, MockProduct.GetProducts());
        }

        [Fact]
        public async void Create_CountIncreaseBy1()
        {
            int count = MockProduct.GetProducts().Count();
            await _productRepository.Create(new Product()
            {
                Id = "1",
                Name = "Test",
                Description = "Test",
                Images = ["test1", "test2"],
                Slug = "Test",
                Price = 20000,
                IsDeleted = true,
            });


            Assert.Equal(count + 1, MockProduct.GetProducts().Count());
        }
    }
}
