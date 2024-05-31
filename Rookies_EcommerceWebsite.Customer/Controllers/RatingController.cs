using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class RatingController : Controller
    {
        private readonly RatingService _ratingService;

        public RatingController(RatingService ratingService)
        {
            this._ratingService = ratingService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Create(CreateRatingModel model)
        {
            if (ModelState.IsValid)
            {
                Rating rating = new Rating()
                {
                    PhoneNumber = model.PhoneNumber,
                    ProductId = model.ProductId,
                    FullName = model.FullName,
                    Content = model.Content,
                    Email = model.Email,
                    Rate = model.Rate,
                };
                await _ratingService.Create(rating);
            }
            else
            {
                TempData["Message"] = "Please fill all the input before submitting";
            }
            return RedirectToAction("Detail", "Product", new { id = model.RedirectSlug });
        }
    }
}
