using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookies_EcommerceWebsite.Controllers;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using Rookies_EcommerceWebsite.Tests.API.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rookies_EcommerceWebsite.Tests.API
{
    public class ProductControllerTesting
    {
        private readonly ProductController controller;
        private readonly ProductService service;


        public ProductControllerTesting()
        {
            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Scheme).Returns("http");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("http://localhost:8080"));
            request.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            var httpContext = Mock.Of<HttpContext>(_ =>
                _.Request == request.Object
            );



            var mockSet = new Mock<DbSet<Product>>();
            mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(MockProduct.GetProducts().AsQueryable().Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(MockProduct.GetProducts().AsQueryable().Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(MockProduct.GetProducts().AsQueryable().ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(MockProduct.GetProducts().GetEnumerator());


            var _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            var _productRepository = new ProductRepository(_mockContext.Object);
            service = new ProductService(_productRepository);

            var mapper = new Mock<IMapper>().Object;



            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            controller = new ProductController(service, mapper)
            {
                ControllerContext = controllerContext
            };
        }

        private static HttpContext CreateMockHttpContext() =>
            new DefaultHttpContext
            {
                // RequestServices needs to be set so the IResult implementation can log.
                RequestServices = new ServiceCollection().AddLogging().BuildServiceProvider(),
                Response =
                {
                    // The default response body is Stream.Null which throws away anything that is written to it.
                    Body = new MemoryStream(),
                },
            };

        [Fact]
        public async void ProductController_TestingGetAllReturnType()
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.Get();
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseProduct = await JsonSerializer.DeserializeAsync<List<Product>>(mockHttpContext.Response.Body, jsonOptions);


            Assert.Equal(200, mockHttpContext.Response.StatusCode);
            var expected = MockProduct.GetProducts();
            Assert.IsType<List<Product>>(responseProduct);
        }

        [Theory]
        [InlineData("Test-1", "Test-1")]
        [InlineData("Test-2", "Test-2")]

        public async void ProductController_TestingGetBySlugSuccess(string slug, string expect)
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.GetBySlug(slug);
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseProduct = await JsonSerializer.DeserializeAsync<Product>(mockHttpContext.Response.Body, jsonOptions);


            Assert.Equal(200, mockHttpContext.Response.StatusCode);

            Assert.IsType<Product>(responseProduct);

            Assert.True(responseProduct.Slug.Equals(expect));
        }

        [Theory]
        [InlineData("Test-3")]
        [InlineData("Test-4")]
        [InlineData("Default")]
        public async void ProductController_TestingGetBySlugFailed(string slug)
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.GetBySlug(slug);
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;

            Assert.Equal(404, mockHttpContext.Response.StatusCode);
        }

        [Fact]
        public async void ProductController_Create_BadRequest()
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.Create(null);
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;

            Assert.Equal(400, mockHttpContext.Response.StatusCode);
        }

        [Fact]
        public async void ProductController_Update_BadRequest()
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.Update("test1", null);
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;

            Assert.Equal(400, mockHttpContext.Response.StatusCode);
        }

    }
}
