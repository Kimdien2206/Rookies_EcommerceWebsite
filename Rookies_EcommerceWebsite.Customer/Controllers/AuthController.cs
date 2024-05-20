using Microsoft.AspNetCore.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
    }
}
