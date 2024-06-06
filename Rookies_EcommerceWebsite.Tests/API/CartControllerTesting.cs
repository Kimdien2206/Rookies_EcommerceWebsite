using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookies_EcommerceWebsite.Controllers;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using Rookies_EcommerceWebsite.Tests.API.MockData;
using Rookies_EcommerceWebsite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.API
{
    public class CartControllerTesting
    {
        private readonly CartController _controller;
        private readonly CartService _service;


        public CartControllerTesting()
        {
            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Scheme).Returns("http");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("http://localhost:8080"));
            request.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            var httpContext = Mock.Of<HttpContext>(_ =>
                _.Request == request.Object
            );



            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(MockProduct.GetProducts().AsQueryable().Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(MockProduct.GetProducts().AsQueryable().Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(MockProduct.GetProducts().AsQueryable().ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(MockProduct.GetProducts().GetEnumerator());
            
            var mockCartSet = new Mock<DbSet<Cart>>();
            mockCartSet = new Mock<DbSet<Cart>>();
            mockCartSet.As<IQueryable<Cart>>().Setup(m => m.Provider).Returns(MockCart.GetCarts().AsQueryable().Provider);
            mockCartSet.As<IQueryable<Cart>>().Setup(m => m.Expression).Returns(MockCart.GetCarts().AsQueryable().Expression);
            mockCartSet.As<IQueryable<Cart>>().Setup(m => m.ElementType).Returns(MockCart.GetCarts().AsQueryable().ElementType);
            mockCartSet.As<IQueryable<Cart>>().Setup(m => m.GetEnumerator()).Returns(MockCart.GetCarts().GetEnumerator());
            
            var mockVariantSet = new Mock<DbSet<Variant>>();
            mockVariantSet = new Mock<DbSet<Variant>>();
            mockVariantSet.As<IQueryable<Variant>>().Setup(m => m.Provider).Returns(MockVariant.GetVariants().AsQueryable().Provider);
            mockVariantSet.As<IQueryable<Variant>>().Setup(m => m.Expression).Returns(MockVariant.GetVariants().AsQueryable().Expression);
            mockVariantSet.As<IQueryable<Variant>>().Setup(m => m.ElementType).Returns(MockVariant.GetVariants().AsQueryable().ElementType);
            mockVariantSet.As<IQueryable<Variant>>().Setup(m => m.GetEnumerator()).Returns(MockVariant.GetVariants().GetEnumerator());


            var _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Products).Returns(mockProductSet.Object);
            _mockContext.Setup(m => m.Carts).Returns(mockCartSet.Object);
            _mockContext.Setup(m => m.Variants).Returns(mockVariantSet.Object);

            var _cartRepository = new CartRepository(_mockContext.Object);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();
            _service = new CartService(_cartRepository, new UnitOfWork(_mockContext.Object), mapper);




            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            _controller = new CartController(_service, mapper)
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
        public async void Get_ShouldBeResultNoContent_IfListEmpty()
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Get();

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            

            // Assert
            Assert.Equal(204, mockHttpContext.Response.StatusCode);
        }
        
        [Fact]
        public async void Get_ShouldBeResultListCarts_IfListNotEmpty()
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Get();

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseCart = await JsonSerializer.DeserializeAsync<List<Cart>>(mockHttpContext.Response.Body, jsonOptions);

            // Assert
            Assert.Equal(200, mockHttpContext.Response.StatusCode);
            var expected = MockCart.GetCarts();
            Assert.IsType<List<Cart>>(responseCart);
        }
        
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 1)]
        public async void GetByCustomerId_GivenValidId_ShouldBeResultListCarts_IfListNotEmpty(string customerId, int expectCount)
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.GetByCustomerId(customerId);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseCart = await JsonSerializer.DeserializeAsync<List<Cart>>(mockHttpContext.Response.Body, jsonOptions);

            // Assert
            Assert.Equal(200, mockHttpContext.Response.StatusCode);
            var expected = MockCart.GetCarts();
            Assert.IsType<List<Cart>>(responseCart);
            Assert.True(responseCart.Count == expectCount);
        }
        
        [Fact]
        public async void GetByCustomerId_GivenInvalidId_ShouldBeResultNoContentResponse_IfListNotEmpty()
        {
            // Arrange
            var customerId = Guid.NewGuid().ToString();
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.GetByCustomerId(customerId);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            

            // Assert
            Assert.Equal(204, mockHttpContext.Response.StatusCode);
        }

        [Fact]        
        public async void Create_GivenNoData_ShouldBeResultBadRequestResponse()
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Create(null);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            

            // Assert
            Assert.Equal(400, mockHttpContext.Response.StatusCode);
        }
        
        [Fact]        
        public async void Create_GivenInvalidVariantId_ShouldBeResultNotFoundResponse()
        {
            // Arrange
            var newCart = new CreateCartRequestDto()
            {
                CustomerId = Guid.NewGuid().ToString(),
                TotalCost = 50000,
                Amount = 1,
                VariantId = Guid.NewGuid().ToString(),
            };
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Create(newCart);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            

            // Assert
            Assert.Equal(404, mockHttpContext.Response.StatusCode);
        }
        
        [Fact]        
        public async void Create_GivenInvalidCustomerId_ShouldBeResultNotFoundResponse()
        {
            // Arrange
            var newCart = new CreateCartRequestDto()
            {
                CustomerId = Guid.NewGuid().ToString(),
                TotalCost = 50000,
                Amount = 1,
                VariantId = "1",
            };
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Create(newCart);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            

            // Assert
            Assert.Equal(404, mockHttpContext.Response.StatusCode);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        [InlineData("2")]
        public async void Delete_GivenValidCartId_ShouldBeResultOkResponse(string id)
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Delete(id);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;


            // Assert
            Assert.Equal(200, mockHttpContext.Response.StatusCode);
        }

        [Fact]
        public async void Delete_GivenInvalidCartId_ShouldBeResultUnprocessableEntityResponse()
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await _controller.Delete(Guid.NewGuid().ToString());

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;

            // Assert
            Assert.Equal(422, mockHttpContext.Response.StatusCode);
        }
    }
}
