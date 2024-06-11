using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public readonly IRepository<Product> productRepository;
        public readonly IRepository<Invoice> invoiceRepository;
        public readonly IRepository<Cart> cartRepository;
        public readonly IRepository<Variant> variantRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            productRepository = new GenericRepository<Product>(_context);
            invoiceRepository = new GenericRepository<Invoice>(_context);
            cartRepository = new GenericRepository<Cart>(_context);
            variantRepository = new GenericRepository<Variant>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
