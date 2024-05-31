using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Product List";

            List<Product> products = await _productService.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Detail(string id)
        {
            ViewData["Title"] = "Product Detail";

            Product product = await _productService.GetBySlug(id);
            ModelState.Clear();
            return View(product);
        }
    }
}
