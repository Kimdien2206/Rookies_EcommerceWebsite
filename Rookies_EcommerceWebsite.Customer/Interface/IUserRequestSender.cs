using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Interface
{
    public interface IUserRequestSender
    {
        Task<UserInfo> Update(string path, UserInfo entity, string token);

    }
}
