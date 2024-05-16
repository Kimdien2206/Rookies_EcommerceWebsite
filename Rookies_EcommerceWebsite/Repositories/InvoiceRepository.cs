using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class InvoiceRepository : IRepository<Invoice>
    {
        private readonly ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<Invoice> Create(Invoice entity)
        {
            _context.Invoices.Add(entity);
            return entity;
        }

        public async Task<List<Invoice>> GetAll()
        {
            List<Invoice> products = _context.Invoices.ToList();

            return products;
        }

        public async Task<Invoice> GetById(string id)
        {
            Invoice product = _context.Invoices
                .Where(e => e.Id.ToString().Equals(id))
                .Include(u => u.InvoiceVariants)
                .ThenInclude(p => p.Variant)
                .First();

            return product;
        }

        public async Task<List<Invoice>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Update(string id, Invoice entity)
        {
            Invoice product = _context.Invoices.Find(id);

            product.Status = entity.Status;

            return product;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
