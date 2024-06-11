using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.ViewComponents
{
    [ViewComponent]
    public class PaginationViewComponent : ViewComponent
    {
        private readonly IRequestSender<Product> _requestSender;
        public PaginationViewComponent(IRequestSender<Product> requestSender)
        {
            _requestSender = requestSender;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
