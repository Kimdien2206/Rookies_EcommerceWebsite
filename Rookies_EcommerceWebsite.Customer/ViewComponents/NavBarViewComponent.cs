using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.ViewComponents
{
    [ViewComponent]
    public class NavBarViewComponent: ViewComponent
    {
        private readonly ICategoriesClient _categoriesClient;
        private readonly IAuthRequestSender _authRequestSender;


        public NavBarViewComponent(ICategoriesClient categoriesClient, IAuthRequestSender authRequestSender)
        {
            _categoriesClient = categoriesClient;
            _authRequestSender = authRequestSender;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = HttpContext.Request.Cookies["access_token"];
            var id = HttpContext.Request.Cookies["user_id"];
            List<Category> categories = await _categoriesClient.GetAllCategories();
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
