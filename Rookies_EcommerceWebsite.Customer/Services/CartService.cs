using Dtos.Response;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class CartService
    {
        private readonly ICartsClient _cartClient;
        public CartService(ICartsClient cartClient)
        {
            this._cartClient = cartClient;
        }
        
        public async Task<List<GetListCartResponse>> GetAllByCustomerId(string id)
        {
            return await _cartClient.GetAllCartsOfCustomer(id);
        }

        public async Task<Cart> Create(Cart newCart)
        {
            return await _cartClient.CreateCart(newCart);
        }

        public Task Delete(string id)
        {
            return _cartClient.DeleteCart(id);
        }
    }
}
