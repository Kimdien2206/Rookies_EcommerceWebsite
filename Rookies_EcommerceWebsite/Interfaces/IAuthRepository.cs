using Dtos;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IAuthRepository
    {
        Task<IResult> Login(string email, string password);
        Task<IResult> Logout(string email);
        Task<IResult> Register(User user, string password);
        Task<IResult> GetToken(LoginRequestDto userLogins);
        Task<IResult> RefreshToken(RefreshTokenDto userLogins);

    }
}
