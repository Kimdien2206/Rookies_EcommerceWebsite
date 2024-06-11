using Rookies_EcommerceWebsite.Data;
using System.Linq.Expressions;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> Create(T entity);
        Task<T> Update(object id, T entity);
        void Delete(object id);
        Task<T> GetById(object id);
        Task Save();

    }
}
