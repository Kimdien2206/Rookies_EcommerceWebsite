using Microsoft.AspNetCore.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
