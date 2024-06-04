using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.API.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAll();
        Task<Cart> Create(Cart entity);
        Task<Cart> Update(string id, Cart entity);
        Task Delete(string id);
        Task<Cart> GetById(string id);
        Task<List<Cart>> GetByCustomerId(string id);
        Task Save();
    }
}
