using AutoMapper;
using Dtos.Response;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class UserService 
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
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
            List<User> users = await _repository.Get();

            if(users.Count == 0) 
            {
                return Results.NoContent();
            }
            List<GetUserInfoResponse> responses = _mapper.Map<List<GetUserInfoResponse>>(users);

            return Results.Ok(responses);
        }

        public async Task<IResult> GetById(string id)
        {
            User user = await _repository.GetById(id);

            if(user == null)
            {
                return Results.NotFound();
            }

            GetUserInfoResponse response = _mapper.Map<GetUserInfoResponse>(user);

            return Results.Ok(response);    
        }

        public async Task<IResult> Update(string id, User entity)
        {
            User user = await _repository.Update(id, entity);

            if (user == null)
            {
                return Results.NotFound();
            }

            GetUserInfoResponse response = _mapper.Map<GetUserInfoResponse>(user);

            return Results.Ok(response);
        }
    }
}
