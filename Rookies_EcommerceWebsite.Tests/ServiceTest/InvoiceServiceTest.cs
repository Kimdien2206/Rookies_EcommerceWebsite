using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using Rookies_EcommerceWebsite.Tests.MockData;
using Rookies_EcommerceWebsite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.ServiceTest
{
    public class InvoiceServiceTest
    {
        private readonly InvoiceService service;
        public InvoiceServiceTest() 
        {
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
            
            var mockInvoiceSet = new Mock<DbSet<Invoice>>();
            mockInvoiceSet = new Mock<DbSet<Invoice>>();
            mockInvoiceSet.As<IQueryable<Invoice>>().Setup(m => m.Provider).Returns(new List<Invoice>().AsQueryable().Provider);
            mockInvoiceSet.As<IQueryable<Invoice>>().Setup(m => m.Expression).Returns(new List<Invoice>().AsQueryable().Expression);
            mockInvoiceSet.As<IQueryable<Invoice>>().Setup(m => m.ElementType).Returns(new List<Invoice>().AsQueryable().ElementType);
            mockInvoiceSet.As<IQueryable<Invoice>>().Setup(m => m.GetEnumerator()).Returns(new List<Invoice>().GetEnumerator());



            var _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Products).Returns(mockProductSet.Object);
            _mockContext.Setup(m => m.Carts).Returns(mockCartSet.Object);
            _mockContext.Setup(m => m.Variants).Returns(mockVariantSet.Object);
            _mockContext.Setup(m => m.Invoices).Returns(mockInvoiceSet.Object);

            var _invoiceRepository = new InvoiceRepository(_mockContext.Object);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();
            service = new InvoiceService(_invoiceRepository, new UnitOfWork(_mockContext.Object), mapper);
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
        public async void Create_GivenNullData_ShouldBeResultBadRequest()
        {
            // Arrange
            var mockHttpContext = CreateMockHttpContext();
            var result = await service.Create(null);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;

            // Assert
            Assert.Equal(400, mockHttpContext.Response.StatusCode);
        }
        
        [Fact]
        public async void Create_GivenValidData_ShouldBeResultOk()
        {
            // Arrange
            var newInvoice = new CreateInvoiceRequestDto()
            {
                Address = "test",
                Email = "test",
                Name = "test",
                PhoneNumber = "test",
                InvoiceVariants = new List<InvoiceVariantDto>(){
                    new InvoiceVariantDto()
                    {
                        Amount = 4,
                        CartId = "1",
                        VariantId = "1",
                    }
                }
            };
            var mockHttpContext = CreateMockHttpContext();
            var result = await service.Create(newInvoice);

            // Act
            await result.ExecuteAsync(mockHttpContext);
            mockHttpContext.Response.Body.Position = 0;
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var responseInvoice = await JsonSerializer.DeserializeAsync<Invoice>(mockHttpContext.Response.Body, jsonOptions);

            // Assert
            Assert.Equal(200, mockHttpContext.Response.StatusCode);
            Assert.IsType<Invoice>(responseInvoice);
        }
    }
}
