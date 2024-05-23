using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRequestSender _requestSender;

        public AuthController(IAuthRequestSender requestSender)
        {
            this._requestSender = requestSender;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User loggedInUser = await _requestSender.Login(loginModel.UserName, loginModel.Password);
                if (loggedInUser != null)
                {
                    UserToken token = await _requestSender.GetToken(loginModel.UserName, loginModel.Password);
                    Response.Cookies.Append("access_token", token.Token);
                    Response.Cookies.Append("refresh_token", token.RefreshToken);
                    Response.Cookies.Append("role", token.Role);

                    return RedirectToAction("Index", "Home");
                }
            }    
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
    }
}
