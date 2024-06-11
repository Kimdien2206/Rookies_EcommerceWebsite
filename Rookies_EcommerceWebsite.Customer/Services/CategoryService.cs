using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class CategoryService
    {
        private readonly ICategoriesClient _categoriesClient;
        public CategoryService(ICategoriesClient categoriesClient)
        {
            this._categoriesClient = categoriesClient;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _categoriesClient.GetAllCategories();
        }

        public async Task<Category> GetDetail(string id)
        {
            return await _categoriesClient.GetCategoryDetail(id);
        }
    }
}
