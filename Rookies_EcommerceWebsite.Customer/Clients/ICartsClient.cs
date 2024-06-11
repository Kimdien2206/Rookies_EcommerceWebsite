using Dtos.Response;
using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface ICartsClient
    {
        [Get("/Cart/Customer/{id}")]
        Task<List<GetListCartResponse>> GetAllCartsOfCustomer(string id);

        [Post("/Cart")]
        Task<Cart> CreateCart([Body] Cart newCart);

        [Delete("/Cart/{id}")]
        Task DeleteCart(string id);
    }
}
