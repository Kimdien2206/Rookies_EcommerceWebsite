using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public interface IAuthRequestSender 
    {
        Task<User> Login(string username, string password);
        Task<UserToken> GetToken(string username, string password);
        void Logout();
        Task<User> SignUp(User user);

    }
}
