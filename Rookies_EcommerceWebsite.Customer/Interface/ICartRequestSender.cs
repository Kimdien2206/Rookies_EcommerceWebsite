using Dtos.Response;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Interface
{
    public interface ICartRequestSender
    {
        Task<List<Cart>> GetList();
        Task<List<GetListCartResponse>> GetByCustomerId(string id);
        Task<Cart> GetDetail(string id);
        Task<Cart> Create(Cart entity);
        Task<Task> Delete(string id);
    }
}
