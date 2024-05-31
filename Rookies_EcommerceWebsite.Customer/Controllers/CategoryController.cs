using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<IActionResult> Detail(string id)
        {
            Category detail = await _categoryService.GetDetail(id); 

            return View(detail);
        }
    }
}
