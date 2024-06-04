using Dtos.Response;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class CartService
    {
        private readonly ICartRequestSender _requestSender;
        public CartService(ICartRequestSender requestSender)
        {
            this._requestSender = requestSender;
        }
        public async Task<List<Cart>> GetAll()
        {
            return await _requestSender.GetList();
        }
        
        public async Task<List<GetListCartResponse>> GetAllByCustomerId(string id)
        {
            return await _requestSender.GetByCustomerId(id);
        }

        public async Task<Cart> GetDetail(string id)
        {
            return await _requestSender.GetDetail(id);
        }

        public async Task<Cart> Create(Cart newCart)
        {
            return await _requestSender.Create(newCart);
        }

        public Task Delete(string id)
        {
            return _requestSender.Delete(id);
        }
    }
}
