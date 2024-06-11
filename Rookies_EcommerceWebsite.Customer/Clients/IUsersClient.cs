using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface IUsersClient
    {
        [Put("/User/{id}")]
        Task<UserInfo> UpdateUserInfo(string id, [Body] UserInfo newInfo);
    }
}
