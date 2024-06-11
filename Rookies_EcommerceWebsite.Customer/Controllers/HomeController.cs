using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;
using System.Diagnostics;
//using System.Web.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IProductsClient _productsClient;


        public HomeController(IProductsClient productsClient)
        {
            //_logger = logger;
            this._productsClient = productsClient;
        }

        public async Task<IActionResult> Index([FromQuery] string query)
        {
            ViewData["Title"] = "Home";

            List<Product> products = await _productsClient.GetUpcomingProduct();
            if(products is not null &&  products.Count > 0)
            {
                ViewData["Products"] = products;
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
