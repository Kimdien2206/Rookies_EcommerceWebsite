using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.RequestSender;


namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class ProductService
    {
       
        private readonly IRequestSender<Product> _requestSender;

        public ProductService(IRequestSender<Product> requestSender)
        {
            this._requestSender = requestSender;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _requestSender.GetList("Product");
        }

        public async Task<Product> GetBySlug(string slug)
        {
            return await _requestSender.GetDetail("Product", slug);
        }
    }
}
