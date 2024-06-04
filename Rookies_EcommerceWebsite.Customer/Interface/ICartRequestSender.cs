using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Interface
{
    public interface ICartRequestSender
    {
        Task<List<Cart>> GetList(string path);
        Task<Cart> GetDetail(string path, string id);
        Task<Cart> Create(string path, Cart entity);
        Task<Task> Delete(string path, string id);
    }
}
