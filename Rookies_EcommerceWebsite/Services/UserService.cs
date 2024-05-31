using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class UserService 
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            this._repository = repository;
        }

        public Task<IResult> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> GetAll()
        {
            List<User> users = await _repository.GetAll();

            if(users.Count == 0) 
            {
                return Results.NoContent();
            }

            return Results.Ok(users);
        }

        public async Task<IResult> GetById(string id)
        {
            User user = await _repository.GetById(id);

            if(user == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(user);    
        }

        public Task<IResult> Update(string id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
