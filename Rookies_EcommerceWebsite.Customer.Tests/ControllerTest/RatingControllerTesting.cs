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
    public class RatingControllerTesting
    {
        private readonly RatingController _controller;

        public RatingControllerTesting()
        {
            var mockRequest = new Mock<IRequestSender<Rating>>();
            mockRequest.Setup(m => m.Create("Rating", It.IsAny<Rating>())).ReturnsAsync(new Rating());

            var service = new RatingService(mockRequest.Object);

            this._controller = new RatingController(service);
        }

        [Fact]
        public async void Create_GivenInvalidData_ShouldBeReturnValidView()
        {
            // Arrange
            var result = await _controller.Create(new CreateRatingModel() { RedirectSlug = "1"}) as RedirectToActionResult;

            // Act
            var actionName = result.ActionName;
            var controllerName = result.ControllerName;

            // Assert
            Assert.Equal("Detail", actionName);
            Assert.Equal("Product", controllerName);
        }
    }
}
