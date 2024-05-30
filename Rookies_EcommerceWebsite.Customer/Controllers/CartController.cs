using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        public CartController(CartService cartService)
        {
            this._cartService = cartService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = HttpContext.Session.GetString("Id");
            List<Cart> carts;
            if(userId != null) 
            {
                carts = await _cartService.GetAll();
                if(carts is not null)
                {

                ViewData["Carts"] = carts.ToArray();
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart creatingCart, string Command, string Slug)
        {
            switch (Command)
            {
                case "Add to Cart":
                    await _cartService.Create(creatingCart);
                    return RedirectToAction("Detail", "Product", new { id = Slug });
                case "Buy now":
                    return RedirectToAction("Index", "Cart");
                default:
                    return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCart(string id)
        {
            Task task = _cartService.Delete(id);
            task.Wait();
            if (task.IsCompleted)
            {
                return RedirectToAction("Index", "Cart");
            }
            return BadRequest();
        }
    }
}
