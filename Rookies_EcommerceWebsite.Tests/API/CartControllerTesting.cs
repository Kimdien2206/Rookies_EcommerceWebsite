using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rookies_EcommerceWebsite.Controllers;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Services;
using Rookies_EcommerceWebsite.Tests.API.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



            var mockSet = new Mock<DbSet<Cart>>();
            mockSet = new Mock<DbSet<Cart>>();
            mockSet.As<IQueryable<Cart>>().Setup(m => m.Provider).Returns(MockCart.GetCarts().AsQueryable().Provider);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.Expression).Returns(MockCart.GetCarts().AsQueryable().Expression);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.ElementType).Returns(MockCart.GetCarts().AsQueryable().ElementType);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.GetEnumerator()).Returns(MockCart.GetCarts().GetEnumerator());


            var _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Carts).Returns(mockSet.Object);
            var _cartRepository = new CartRepository(_mockContext.Object);
            var mapper = new Mock<IMapper>().Object;
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
    }
}
