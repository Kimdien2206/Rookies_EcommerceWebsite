using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public interface IAuthRequestSender 
    {
        Task<UserInfo> Login(string username, string password);
        Task<UserToken> GetToken(string username, string password);
        void Logout();
        Task<UserInfo> SignUp(UserInfo user);
        Task<UserInfo> GetUserInfo(string id, string token);
    }
}
