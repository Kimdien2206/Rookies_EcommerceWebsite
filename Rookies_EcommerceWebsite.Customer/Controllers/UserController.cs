﻿using Microsoft.AspNetCore.Mvc;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "User";

            return View();
        }
    }
}
