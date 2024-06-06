using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.API.Interfaces;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        } 
        public async Task<Cart> Create(Cart entity)
        {
            _context.Carts.Add(entity);
            return entity;
        }

        public Task Delete(string id)
        {
            Cart cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if(cart != null)
            {
                _context.Carts.Remove(cart);
                return Task.CompletedTask;
            }
            return Task.FromException(new KeyNotFoundException());
        }

        public async Task<List<Cart>> GetAll()
        {
            List<Cart> cart = _context.Carts.Include(u => u.Variant).ToList();
            return cart;
        }

        public async Task<List<Cart>> GetByCustomerId(string id)
        {
            List<Cart> carts = _context.Carts.Include(u => u.Variant).Where(u => u.CustomerId.Equals(id)).ToList();
            return carts;
        }

        public async Task<Cart> GetById(string id)
        {
            Cart cart = _context.Carts.FirstOrDefault(x => x.Id == id);
            return cart;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<Cart>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> SearchIfExistCart(string userId, string variantId)
        {
            return _context.Carts.Where(u => (u.VariantId.Equals(variantId) && u.CustomerId.Equals(userId))).FirstOrDefault();
        }

        public async Task<Cart> Update(string id, Cart entity)
        {
            Cart cart = _context.Carts.Find(id);

            cart.Amount = entity.Amount;
            cart.TotalCost = entity.TotalCost;

            return cart;
        }
    }
}
