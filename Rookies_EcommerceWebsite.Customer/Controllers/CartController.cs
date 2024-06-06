using Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;
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
            ViewData["Title"] = "Cart";
            string userId = HttpContext.Session.GetString("Id");
            List<GetListCartResponse> carts;
            if(userId != null) 
            {
                carts = await _cartService.GetAllByCustomerId(userId);
                if(carts is not null)
                {
                    ViewData["Carts"] = carts.ToArray();
                }
            }

            string name = HttpContext.Session.GetString("LastName");
            string phoneNumber = HttpContext.Session.GetString("PhoneNumber");
            string email = HttpContext.Session.GetString("Email");
            string address = HttpContext.Session.GetString("Address");

            InvoiceViewModel viewModel;
            if (name != null)
            {
                viewModel = new InvoiceViewModel()
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Address = address
                };
            }
            else
            {
                viewModel = new InvoiceViewModel();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart creatingCart, string Command, string Slug)
        {   
            if(creatingCart.CustomerId != null)
            {
                Cart newCart = await _cartService.Create(creatingCart);
                switch (Command)
                {
                    case "Add to Cart":
                        if (newCart == null)
                            TempData["AddToCartMessage"] = "Something went wrong while creating Cart";
                        return RedirectToAction("Detail", "Product", new { id = Slug });
                    case "Buy now":
                        if (newCart == null)
                        {
                            TempData["AddToCartMessage"] = "Something went wrong while creating Cart";
                            return RedirectToAction("Detail", "Product", new { id = Slug });
                        }
                        return RedirectToAction("Index", "Cart");
                    default:
                        return NotFound();
                }
            }
            ViewData["Title"] = "Login Required";
            return View("LoginRequired");
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
