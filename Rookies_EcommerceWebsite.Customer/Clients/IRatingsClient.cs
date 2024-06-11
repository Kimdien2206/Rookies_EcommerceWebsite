using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface IRatingsClient
    {
        [Post("/Rating")]
        Task<Rating> CreateRating([Body] Rating newRating);

    }
}
