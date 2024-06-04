using Rookies_EcommerceWebsite.API.Interfaces;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public readonly IProductRepository productRepository;
        public readonly IInvoiceRepository invoiceRepository;
        public readonly IRepository<Cart> cartRepository;
        public readonly IRepository<Variant> variantRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            productRepository = new ProductRepository(_context);
            invoiceRepository = new InvoiceRepository(_context);
            cartRepository = new CartRepository(_context);
            variantRepository = new VariantRepository(_context);
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
