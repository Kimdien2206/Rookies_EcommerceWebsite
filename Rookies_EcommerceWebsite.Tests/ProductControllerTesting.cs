using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookies_EcommerceWebsite.Controllers;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rookies_EcommerceWebsite.Tests
{
    public class ProductControllerTesting
    {
        private readonly ProductController controller;
        private readonly Mock<IService<Product>> service;


        public ProductControllerTesting()
        {
            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Scheme).Returns("http");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("http://localhost:8080"));
            request.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            var httpContext = Mock.Of<HttpContext>(_ =>
                _.Request == request.Object
            );

            service = new Mock<IService<Product>>();
            service.Setup(x => x.GetAll()).ReturnsAsync(Results.Ok(MockProduct.GetProducts()));
            service.SetupSequence(x => 
                x.GetById("1"))
                    .ReturnsAsync(Results.Ok(MockProduct
                        .GetProducts()
                        .FirstOrDefault(i => i.Id.Equals("1"))));
            service.SetupSequence(x => 
                x.GetById("2"))
                    .ReturnsAsync(Results.Ok(MockProduct
                        .GetProducts()
                        .FirstOrDefault(i => i.Id.Equals("2"))));
            //service.SetupSequence(x => x.Create(It.IsAny<Product>())).ReturnsAsync((Product product) => { return Results.Ok(product); });

            var mapper = new Mock<IMapper>().Object;

            

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            controller = new ProductController(service.Object, mapper)
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
        
        [Fact]
        public async void ProductController_TestingGetByIdReturnType()
        {
            var mockHttpContext = CreateMockHttpContext();


            var result = await controller.GetById("1");
            await result.ExecuteAsync(mockHttpContext);

            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseProduct = await JsonSerializer.DeserializeAsync<Product>(mockHttpContext.Response.Body, jsonOptions);


            Assert.Equal(200, mockHttpContext.Response.StatusCode);
            var expected = MockProduct.GetProducts().FirstOrDefault(x => x.Id.Equals("1"));
            Assert.IsType<Product>(responseProduct);
        } 
    }
}
