using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> Create(Rating entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rating>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Rating> GetById(string id)
        {
            Rating Rating = _context.Ratings.FirstOrDefault(x => x.Id.Equals(id));

            return Rating;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<Rating>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Rating> Update(string id, Rating entity)
        {
            Rating Rating = _context.Ratings.Find(id);

            Rating.Content = entity.Content;

            return Rating;
        }
    }
}
