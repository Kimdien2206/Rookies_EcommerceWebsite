using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.ViewComponents
{
    [ViewComponent]
    public class PaginationViewComponent : ViewComponent
    {
        private readonly IProductsClient _productsClient;
        protected int currentPage = 1;
        public PaginationViewComponent(IProductsClient productsClient)
        {
            _productsClient = productsClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int totalPage = await _productsClient.GetTotalProductPage();
            ViewData["TotalPage"] = totalPage;
            return View();
        }
    }
}

