using Microsoft.EntityFrameworkCore;
using Moq;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Tests.RepositoryTest
{
    public class CartRepositoryTesting
    {
        private readonly Mock<ApplicationDbContext> _mockObject;
        private readonly CartRepository _cartRepository;


        public CartRepositoryTesting()
        {
            var mockSet = new Mock<DbSet<Cart>>();
            mockSet = new Mock<DbSet<Cart>>();
            mockSet.As<IQueryable<Cart>>().Setup(m => m.Provider).Returns(MockCart.GetCarts().AsQueryable().Provider);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.Expression).Returns(MockCart.GetCarts().AsQueryable().Expression);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.ElementType).Returns(MockCart.GetCarts().AsQueryable().ElementType);
            mockSet.As<IQueryable<Cart>>().Setup(m => m.GetEnumerator()).Returns(MockCart.GetCarts().GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Cart>())).Callback<Cart>((s) => MockCart.Add(s));

            _mockObject = new Mock<ApplicationDbContext>();
            _mockObject.Setup(m => m.Carts).Returns(mockSet.Object);
            _cartRepository = new CartRepository(_mockObject.Object);
        }

        [Fact]
        public async void GetAll_ReturningType_ListCart()
        {
            // Act
            var carts = await _cartRepository.GetAll();

            // Assert
            Assert.Equal(carts, MockCart.GetCarts());
        }

        //[Fact]
        //public async void Create_CountIncreaseBy1()
        //{
        //    // Arrange
        //    int count = MockCart.GetCarts().Count();

        //    // Act
        //    await _cartRepository.Create(new Cart()
        //    {
        //        Id = "1",
        //        Amount = 1,
        //        CustomerId = "1",
        //        TotalCost = 3000,
        //        VariantId = "1",
        //    });

        //    // Assert
        //    Assert.Equal(count + 1, MockCart.GetCarts().Count());
        //}
    }
}
