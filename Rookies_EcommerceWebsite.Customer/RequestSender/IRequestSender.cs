using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public interface IRequestSender<T>
    {
        Task<List<T>> GetList(string path);
        Task<T> GetDetail (string path, string id);
        Task<T> Create (string path, T entity);
    }
}
