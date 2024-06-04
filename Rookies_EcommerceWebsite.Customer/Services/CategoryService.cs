using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class CategoryService
    {
        private readonly IRequestSender<Category> _requestSender;
        public CategoryService(IRequestSender<Category> requestSender)
        {
            this._requestSender = requestSender;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _requestSender.GetList("Category");
        }

        public async Task<Category> GetDetail(string id)
        {
            return await _requestSender.GetDetail("Category", id);
        }
    }
}
