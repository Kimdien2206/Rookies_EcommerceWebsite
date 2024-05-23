using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Cart creatingCart)
        //{

        //}
    }
}
