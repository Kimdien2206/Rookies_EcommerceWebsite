using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ProductService productService = new ProductService();
            List<Product> products = await productService.GetAll();
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            return View();
        }
    }
}
