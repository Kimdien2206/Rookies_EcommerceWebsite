using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "User";
            string lastName = HttpContext.Session.GetString("LastName");
            string firstName = HttpContext.Session.GetString("FirstName");
            string phoneNumber = HttpContext.Session.GetString("PhoneNumber");
            string email = HttpContext.Session.GetString("Email");
            string address = HttpContext.Session.GetString("Address");

            UserInfo userInfo = new UserInfo()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Address = address,
                PhoneNumber = phoneNumber
            };

            return View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserInfo userInfo)
        {


            return RedirectToAction("Index");
        }
    }
}
