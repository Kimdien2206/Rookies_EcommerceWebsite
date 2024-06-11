using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Rookies_EcommerceWebsite.Repositories
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

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            dbSet.AddAsync(entity);
            return entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            _context.Remove(entityToDelete);
        }

        public virtual async Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IQueryable<TEntity>> queryFunc = null, 
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

            if (queryFunc != null)
            {
                return queryFunc(query).ToList();
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

        public virtual async Task<TEntity> Update(object id, TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task<TEntity> GetById(object id)
        {
            return dbSet.Find(id);
        }
    }
}
