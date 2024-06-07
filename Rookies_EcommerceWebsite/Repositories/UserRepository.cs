using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();

        }

        public Task<List<User>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(string id, User entity)
        {
            User currentUser = _context.Users.Find(id);

            currentUser.Address = entity.Address;
            currentUser.Email = entity.Email;
            currentUser.FirstName = entity.FirstName;
            currentUser.LastName = entity.LastName;
            currentUser.PhoneNumber = entity.PhoneNumber;

            return currentUser;
        }
    }
}
