using Rookies_EcommerceWebsite.Data;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<List<T>> Search(string searchString);
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task Delete(string id);
        public Task<T> GetById(string id);

    }
}
