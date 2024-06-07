using Rookies_EcommerceWebsite.Data;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(string id, T entity);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task Save();

    }
}
