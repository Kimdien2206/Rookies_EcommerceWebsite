using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface IProductsClient
    {
        [Get("/Product?page={page}")]
        Task<List<Product>> GetAllProducts([Query] string page);
        
        [Get("/Product/{slug}")]
        Task<Product> GetProductsBySlug(string slug);
        
        [Get("/Product/Upcoming")]
        Task<List<Product>> GetUpcomingProduct();
          
        [Get("/Product/PageQuantity")]
        Task<int> GetTotalProductPage();


    }
}
