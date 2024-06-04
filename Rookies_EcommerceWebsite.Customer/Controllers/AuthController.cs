using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;

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
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserInfo loggedInUser = await _requestSender.Login(loginModel.UserName, loginModel.Password);
                if (loggedInUser != null)
                {
                    UserToken token = await _requestSender.GetToken(loginModel.UserName, loginModel.Password);
                    Response.Cookies.Append("access_token", token.Token);
                    Response.Cookies.Append("user_id", token.Id);
                    Response.Cookies.Append("refresh_token", token.RefreshToken);

                    UserInfo userInfo = await _requestSender.GetUserInfo(token.Id, token.Token);
                    HttpContext.Session.SetString("LastName", userInfo.LastName);
                    HttpContext.Session.SetString("FirstName", userInfo.FirstName);
                    HttpContext.Session.SetString("Address", userInfo.Address);
                    HttpContext.Session.SetString("PhoneNumber", userInfo.PhoneNumber);
                    HttpContext.Session.SetString("Email", userInfo.Email);
                    HttpContext.Session.SetString("Id", userInfo.Id);

                    return RedirectToAction("Index", "Home");
                }
            }    
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserInfo userInfo = await _requestSender.SignUp(model);
                if(userInfo != null) 
                {
                    UserToken token = await _requestSender.GetToken(model.Username, model.ConfirmPassword);
                    Response.Cookies.Append("access_token", token.Token);
                    Response.Cookies.Append("user_id", token.Id);
                    Response.Cookies.Append("refresh_token", token.RefreshToken);

                    HttpContext.Session.SetString("LastName", userInfo.LastName);
                    HttpContext.Session.SetString("Id", userInfo.Id);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("refresh_token");
            Response.Cookies.Delete("user_id");

            HttpContext.Session.Clear();    

            return RedirectToAction("Index", "Home");
        }
    }
}
