using Rookies_EcommerceWebsite.Data;
using System.Linq.Expressions;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
        );
        TEntity GetById(object id);
        TEntity Create(TEntity entity);
        TEntity Update(object id, TEntity entity);
        Task Delete(object id);
        Task Save();

    }
}
