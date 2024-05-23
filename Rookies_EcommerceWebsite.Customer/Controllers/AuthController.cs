using Microsoft.AspNetCore.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
    }
}
