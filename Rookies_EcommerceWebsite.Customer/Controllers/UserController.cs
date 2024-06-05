using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            this._userService = userService;
        }
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
            string userId = HttpContext.Session.GetString("Id");
                string token = HttpContext.Request.Cookies["access_token"];

            if(userId != null && token != null && ModelState.IsValid)
            {

                UserInfo newInfo = await _userService.Update(userId, userInfo, token);
                HttpContext.Session.SetString("LastName", newInfo.LastName);
                HttpContext.Session.SetString("FirstName", newInfo.FirstName);
                HttpContext.Session.SetString("PhoneNumber", newInfo.PhoneNumber);
                HttpContext.Session.SetString("Email", newInfo.Email);
                HttpContext.Session.SetString("Address", newInfo.Address);
            }

            TempData["Message"] = "Missing fields data";
            return RedirectToAction("Index");
        }
    }
}
