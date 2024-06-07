using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Rookies_EcommerceWebsite.API.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context; 
        internal DbSet<TEntity> dbSet;


        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public virtual TEntity Update(object id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
