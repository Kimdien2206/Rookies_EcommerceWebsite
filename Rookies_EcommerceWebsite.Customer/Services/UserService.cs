using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class UserService
    {
        private readonly IRequestSender<UserInfo> _requestSender;

        public UserService(IRequestSender<UserInfo> requestSender)
        {
            this._requestSender = requestSender;
        }


    }
}
