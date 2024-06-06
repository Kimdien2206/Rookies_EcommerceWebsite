using Microsoft.AspNetCore.Mvc;
using Moq;
using Rookies_EcommerceWebsite.Customer.Controllers;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.MVC
{
    public class ProductControllerTesting
    {
        private readonly ProductController _controller;

        public ProductControllerTesting()
        {
            var mockRequest = new Mock<IRequestSender<Product>>();
            mockRequest.Setup(m => m.GetList("Product")).ReturnsAsync(new List<Product>()
            {
                new Product()
                {
                    Id = "1",
                    Name = "Test1",
                    Description = "Test1",
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
            });
            mockRequest.Setup(m => m.GetDetail("Product", "Test-1")).ReturnsAsync(new Product()
            {
                Id = "1",
                Name = "Test",
                Description = "Test",
                Images = ["test1", "test2"],
                Slug = "Test-1",
                Price = 20000,
                IsDeleted = true,
            });
            
            mockRequest.Setup(m => m.GetDetail("Product", "Test-2")).ReturnsAsync(new Product()
            {
                Id = "2",
                Name = "Test2",
                Description = "Test2",
                Images = ["test1", "test2"],
                Slug = "Test-2",
                Price = 20000,
                IsDeleted = true,
            });

            var service = new ProductService(mockRequest.Object);
            this._controller = new ProductController(service);
        }

        [Theory]
        [InlineData("Test-1")]
        [InlineData("Test-2")]
        public async void Detail_GivenValidSlug_ShouldBeReturnValidView(string slug)
        {
            // Arrange
            var result = await _controller.Detail(slug) as ViewResult;

            // Act
            var viewName = result.ViewName;
            var model = result.Model;
            var viewTitle = result.ViewData["Title"];

            // Assert
            Assert.Equal("Detail", viewName);
            Assert.True(model != null);
            Assert.Equal("Product Detail", viewTitle);
        }
        
        [Theory]
        [InlineData("Test-3")]
        [InlineData("default")]
        public async void Detail_GivenInvalidSlug_ShouldBeReturnInvalidView(string slug)
        {
            // Arrange
            var result = await _controller.Detail(slug) as ViewResult;

            // Act
            var viewName = result.ViewName;

            // Assert
            Assert.Equal("Error", viewName);
        }
        
        [Fact]
        public async void ProductController_Index_ViewReturn()
        {
            //Arrange
            var result = await _controller.Index() as ViewResult;
            
            // Act
            var viewName = result.ViewName;
            var model = result.Model;
            var viewTitle = result.ViewData["Title"];
            
            // Assert
            Assert.True(model != null);
            Assert.Equal("Index", viewName);
            Assert.Equal("Product List", viewTitle);
        }
    }
}
