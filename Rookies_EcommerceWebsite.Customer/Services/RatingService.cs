using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class RatingService
    {
        private readonly IRatingsClient _ratingsClient;

        public RatingService(IRatingsClient ratingsClient)
        {
            this._ratingsClient = ratingsClient;
        }

        public async Task<Rating> Create(Rating model)
        {
            return await _ratingsClient.CreateRating(model);
        }
    }
}
