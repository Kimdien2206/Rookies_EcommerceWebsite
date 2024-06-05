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

namespace Rookies_EcommerceWebsite.Customer.Tests.MVC
{
    public class CategoryControllerTesting
    {
        private readonly CategoryController _controller;
        public CategoryControllerTesting() {
            var mockRequest = new Mock<IRequestSender<Category>>();
            mockRequest.Setup(m => m.GetList("Category")).ReturnsAsync(new List<Category>()
            {
                new Category()
                {
                    Id = "1",
                    Name = "Test1",
                    Description = "Test1",  
                    IsDeleted = false,
                },
                new Category()
                {
                    Id = "2",
                    Name = "Test2",
                    Description = "Test2",
                    IsDeleted = false,
                }
            });
            mockRequest.Setup(m => m.GetDetail("Category", "1")).ReturnsAsync(new Category()
            {
                Id = "1",
                Name = "Test1",
                Description = "Test1",
                IsDeleted = false,
            });
            mockRequest.Setup(m => m.GetDetail("Category", "2")).ReturnsAsync(new Category()
            {
                Id = "2",
                Name = "Test2",
                Description = "Test2",
                IsDeleted = false,
            });

            var service = new CategoryService(mockRequest.Object);
            this._controller = new CategoryController(service);
        }

        [Theory]
        [InlineData("1", "Test1")]
        [InlineData("2", "Test2")]
        public async void Detail_GivenValidId_ShouldBeReturnValidView(string id, string titleExpect)
        {
            // Arrange
            var result = await _controller.Detail(id) as ViewResult;

            // Act 
            var viewName = result.ViewName;
            var model = result.Model;
            var viewData = result.ViewData["Title"];

            // Assert
            Assert.Equal("Detail", viewName);
            Assert.True(model != null);
            Assert.Equal(viewData, titleExpect);
        }
        
        [Theory]
        [InlineData("4")]
        [InlineData("default")]
        public async void Detail_GivenInvalidId_ShouldBeReturnInvalidView(string id)
        {
            // Arrange
            var result = await _controller.Detail(id) as ViewResult;

            // Act 
            var viewName = result.ViewName;

            // Assert
            Assert.Equal("Error", viewName);
        }
    }
}
