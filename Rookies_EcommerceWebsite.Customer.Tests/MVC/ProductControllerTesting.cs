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
            });
            mockRequest.Setup(m => m.GetDetail("Product", "1")).ReturnsAsync(new Product()
            {
                Id = "1",
                Name = "Test",
                Description = "Test",
                Images = ["test1", "test2"],
                Slug = "Test-1",
                Price = 20000,
                IsDeleted = true,
            });

            var service = new ProductService(mockRequest.Object);
            this._controller = new ProductController(service);
        }

        [Fact]
        public async void ProductController_Detail_ViewReturn()
        {
            var result = await _controller.Detail("1") as ViewResult;

            Assert.Equal("Detail", result.ViewName);
            Assert.True(result.Model != null);
            Assert.Equal(result.ViewData["Title"], "Product Detail");
        }
        
        [Fact]
        public async void ProductController_Index_ViewReturn()
        {
            var result = await _controller.Index() as ViewResult;

            Assert.True(result.Model != null);
            Assert.Equal("Index", result.ViewName);
            Assert.Equal(result.ViewData["Title"], "Product List");
        }
    }
}
