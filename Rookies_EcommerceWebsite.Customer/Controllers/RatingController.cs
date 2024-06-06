using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers;

public class RatingController(RatingService ratingService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateRatingModel model)
    {
        if (ModelState.IsValid)
        {
            var rating = new Rating()
            {
                PhoneNumber = model.PhoneNumber,
                ProductId = model.ProductId,
                FullName = model.FullName,
                Content = model.Content,
                Email = model.Email,
                Rate = model.Rate,
            };
            await ratingService.Create(rating);
        }
        else
        {
            TempData["Message"] = "Please fill all the input before submitting";
        }
        return RedirectToAction("Detail", "Product", new { id = model.RedirectSlug });
    }
}

