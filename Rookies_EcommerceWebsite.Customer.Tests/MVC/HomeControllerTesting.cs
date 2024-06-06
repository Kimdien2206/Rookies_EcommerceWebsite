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
    public class HomeControllerTesting
    {
        private readonly HomeController _controller;

        public HomeControllerTesting()
        {
            var mockRequest = new Mock<IRequestSender<Product>>();
            mockRequest.Setup(m => m.GetList("Product/Upcoming")).ReturnsAsync(new List<Product>()
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
                    Id = "1",
                    Name = "Test1",
                    Description = "Test1",
                    Images = ["test1", "test2"],
                    Slug = "Test-1",
                    Price = 20000,
                    IsDeleted = true,
                }
            });

            this._controller = new HomeController(mockRequest.Object);
        }

        [Fact]
        public async void Index_ShouldBeReturnValidView()
        {
            // Arrange
            var result = await _controller.Index("") as ViewResult;

            // Act
            var viewName = result.ViewName;
            var viewTitle = result.ViewData["Title"];

            // Assert
            Assert.Equal("Index", viewName);
            Assert.Equal("Home", viewTitle);
        }        
        
        [Fact]
        public async void Privacy_ShouldBeReturnCorrectView()
        {
            //Arrange
            var result = _controller.Privacy() as ViewResult;
            
            // Act
            var viewName = result.ViewName;
            var model = result.Model;
            var viewTitle = result.ViewData["Title"];
            
            // Assert
            Assert.True(model == null);
            Assert.Equal("Privacy", viewName);
            //Assert.Equal("Privacy", viewTitle);
        }
    }
}
