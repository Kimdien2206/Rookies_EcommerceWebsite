using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.ViewComponents
{
    [ViewComponent]
    public class NavBarViewComponent: ViewComponent
    {
        private readonly IRequestSender<Category> _requestSender;

        public NavBarViewComponent(IRequestSender<Category> requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.User;
            List<Category> categories = await _requestSender.GetList("Category");
            UserInfo userModel = new UserInfo()
            {
                FirstName = "test1",
                LastName = "test1",
            };
            ViewData["Categories"] = categories;
            ViewData["User"] = userModel;
            return View();
        }
    }
}
