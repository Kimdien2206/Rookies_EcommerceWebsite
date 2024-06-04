using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;

namespace Rookies_EcommerceWebsite.Customer.Interface
{
    public interface IAuthRequestSender
    {
        Task<UserInfo> Login(string username, string password);
        Task<UserToken> GetToken(string username, string password);
        void Logout();
        Task<UserInfo> SignUp(RegisterViewModel user);
        Task<UserInfo> GetUserInfo(string id, string token);
    }
}
