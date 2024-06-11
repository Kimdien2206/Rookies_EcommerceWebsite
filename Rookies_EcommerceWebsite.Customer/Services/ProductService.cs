using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Clients;


namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class ProductService
    {
        private readonly IProductsClient _productsClient;

        public ProductService(IProductsClient productsClient)
        {
            this._productsClient = productsClient;
        }
        public async Task<List<Product>> GetAll(string page)
        {
            return await _productsClient.GetAllProducts(page);
        }

        public async Task<Product> GetBySlug(string slug)
        {
            return await _productsClient.GetProductsBySlug(slug);
        }
    }
}
