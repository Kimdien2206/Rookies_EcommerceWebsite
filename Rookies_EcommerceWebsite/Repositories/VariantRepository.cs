using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class VariantRepository : IRepository<Variant>
    {
        private readonly ApplicationDbContext _context;

        public VariantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Variant> Insert(Variant entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public Task Delete(string id)
        {
            Variant variant = _context.Variants.Find(id);

            variant.IsDeleted = true;

            return Task.CompletedTask;
        }

        public Task<List<Variant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Variant> GetById(string id)
        {
            Variant variant = _context.Variants.FirstOrDefault(x => x.Id.Equals(id));

            return variant;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<Variant>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Variant> Update(string id, Variant entity)
        {
            Variant variant = _context.Variants.Find(id);

            variant.Name = entity.Name;
            variant.Stock = entity.Stock;

            return variant;
        }
    }
}
