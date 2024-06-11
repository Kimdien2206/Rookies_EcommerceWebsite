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

        public async Task<IActionResult> Index([FromQuery(Name = "page")] string pageIndex)
        {
            ViewData["Title"] = "Product List";

            List<Product> products = await _productService.GetAll(pageIndex);
            return View("Index", products);
        }

        public async Task<IActionResult> Detail(string id)
        {
            ViewData["Title"] = "Product Detail";

            Product product = await _productService.GetBySlug(id);
            if(product != null)
            {
                ModelState.Clear();
                return View("Detail", product);
            }
            return View("Error", new ErrorViewModel() { RequestId = null});
        }
    }
}
