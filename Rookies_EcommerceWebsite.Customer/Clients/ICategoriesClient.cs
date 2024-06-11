using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface ICategoriesClient
    {
        [Get("/Category")]
        Task<List<Category>> GetAllCategories();

        [Get("/Category/{id}")]
        Task<Category> GetCategoryDetail(string id);
    }
}
