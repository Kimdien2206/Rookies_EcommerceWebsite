using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class UserService
    {
        private readonly IUsersClient _usersClient;

        public UserService(IUsersClient usersClient)
        {
            this._usersClient = usersClient;
        }

        public async Task<UserInfo> Update(string id, UserInfo model, string token)
        {
            return await _usersClient.UpdateUserInfo(id, model);
        }
    }
}
