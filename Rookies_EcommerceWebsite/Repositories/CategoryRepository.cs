using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<Category> Create(Category entity)
        {
            _context.Categories.Add(entity);

            return entity;
        }

        public Task Delete(string id)
        {
            Category deleteCategory = _context.Categories.Find(id);
            if (deleteCategory != null)
            {
                return Task.FromException(new KeyNotFoundException("Deleting object doesn't exist"));
            }

            deleteCategory.IsDeleted = true;

            return Task.CompletedTask;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = _context.Categories.ToList();

            return categories;
        }

        public async Task<Category> GetById(string id)
        {
            Category category = _context.Categories
                .Include(u => u.Products)
                .IgnoreAutoIncludes()
                .FirstOrDefault(x => x.Id.Equals(id));

            return category;
        }

        public Task<List<Category>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(string id, Category entity)
        {
            Category category = _context.Categories.Find(id);

            category.Name = entity.Name;
            category.Description = entity.Description;
            category.UpdatedDate = DateTime.Now;

            return category;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
