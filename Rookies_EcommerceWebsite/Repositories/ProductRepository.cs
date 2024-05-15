using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<Product> Create(Product entity)
        {
            _context.Products.Add(entity);
            return entity;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = _context.Products.Include(u => u.Category).ToList();

            return products;
        }

        public async Task<Product> GetById(string id)
        {
            Product product = _context.Products
                .Where(e => e.Id.ToString().Equals(id))
                .Include(u => u.Variants)
                .Include(i => i.Category)
                .First();

            return product;
        }

        public async Task<List<Product>> Search(string searchString)
        {
            List<Product> products = _context.Products.Where(u => u.Name.StartsWith(searchString)).ToList();

            return products;
        }

        public async Task<Product> Update(string id, Product entity)
        {
            Product product = _context.Products.Find(id);

            product.Name = entity.Name;
            product.Category = entity.Category;
            product.Description = entity.Description;
            product.UpdatedDate = DateTime.Now;

            return product;
        }

        public Task Delete(string id)
        {
            Product deleteProduct = _context.Products.Find(id);

            if(deleteProduct == null) 
            {
                return Task.FromException(new KeyNotFoundException());
            }

            deleteProduct.IsDeleted = true; 

            return Task.CompletedTask;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
