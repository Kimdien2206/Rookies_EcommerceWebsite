using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IAuthRepository
    {

        public Task<IResult> Login(string email, string password);
        public Task<IResult> Register(User user, string password);

    }
}
