using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class ProductRepository : IProductRepository
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
            List<Product> products = _context.Products.ToList();

            return products;
        }

        public async Task<Product> GetBySlug(string slug)
        {
            Product product = _context.Products
                .Where(e => e.Slug.ToString().Equals(slug))
                .Include(u => u.Variants)
                .Include(i => i.Ratings)
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
            product.CategoryId = entity.CategoryId;
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

        public async Task<Product> GetById(string id)
        {
            Product product = _context.Products.Find(id);

            return product;
        }
    }
}
