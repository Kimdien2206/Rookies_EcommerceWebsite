using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class UserService
    {
        private readonly IUserRequestSender _requestSender;

        public UserService(IUserRequestSender requestSender)
        {
            this._requestSender = requestSender;
        }

        public async Task<UserInfo> Update(string id, UserInfo model, string token)
        {
            return await _requestSender.Update(id, model, token);
        }
    }
}
