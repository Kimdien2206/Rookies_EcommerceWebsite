using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;
using Rookies_EcommerceWebsite.Customer.Services;
using System.Diagnostics;
//using System.Web.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestSender<Product> _requestSender;


        public HomeController(ILogger<HomeController> logger, IRequestSender<Product> requestSender)
        {
            _logger = logger;
            this._requestSender = requestSender;
        }

        public async Task<IActionResult> Index([FromQuery] string query)
        {
            ViewData["Title"] = "Home";

            List<Product> products = await _requestSender.GetList("Product/Upcoming");
            if(products is not null &&  products.Count > 0)
            {
                ViewData["Products"] = products;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
