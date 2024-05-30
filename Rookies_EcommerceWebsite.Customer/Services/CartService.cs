using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

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
            return await _requestSender.GetList("Cart");
        }

        public async Task<Cart> GetDetail(string id)
        {
            return await _requestSender.GetDetail("Cart", id);
        }

        public async Task<Cart> Create(Cart newCart)
        {
            return await _requestSender.Create("Cart", newCart);
        }

        public Task Delete(string id)
        {
            return _requestSender.Delete("Cart", id);
        }
    }
}
