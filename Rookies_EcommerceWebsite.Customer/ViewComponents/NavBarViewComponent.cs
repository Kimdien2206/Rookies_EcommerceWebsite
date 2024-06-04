using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.ViewComponents
{
    [ViewComponent]
    public class NavBarViewComponent: ViewComponent
    {
        private readonly IRequestSender<Category> _requestSender;
        private readonly IAuthRequestSender _authRequestSender;


        public NavBarViewComponent(IRequestSender<Category> requestSender, IAuthRequestSender authRequestSender)
        {
            _requestSender = requestSender;
            _authRequestSender = authRequestSender;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = HttpContext.Request.Cookies["access_token"];
            var id = HttpContext.Request.Cookies["user_id"];
            List<Category> categories = await _requestSender.GetList("Category");
            ViewData["Categories"] = categories;
            UserInfo userModel = new UserInfo();
            if (HttpContext.Session.GetString("LastName") == null)
            {
                userModel = await _authRequestSender.GetUserInfo(id, token);
                if (userModel != null)
                {
                    HttpContext.Session.SetString("LastName", userModel.LastName);
                    HttpContext.Session.SetString("FirstName", userModel.FirstName);
                    HttpContext.Session.SetString("Address", userModel.Address);
                    HttpContext.Session.SetString("PhoneNumber", userModel.PhoneNumber);
                    HttpContext.Session.SetString("Email", userModel.Email);
                    HttpContext.Session.SetString("Id", userModel.Id);
                    ViewData["User"] = userModel;
                }
                else
                {
                    ViewData["User"] = null;
                }
            }
            else
            {
                userModel.LastName = HttpContext.Session.GetString("LastName");
                userModel.Id = HttpContext.Session.GetString("Id");
                ViewData["User"] = userModel;
            }
            return View();
        }
    }
}
