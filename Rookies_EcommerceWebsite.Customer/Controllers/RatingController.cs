using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRatingModel model)
        {

            return RedirectToAction("Detail", "Product", model.ProductId);
        }
    }
}
