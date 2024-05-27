using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class RatingService
    {
        private readonly IRequestSender<Rating> _requestSender;

        public RatingService(IRequestSender<Rating> requestSender)
        {
            this._requestSender = requestSender;
        }
        public async Task<List<Rating>> GetAll()
        {
            return await _requestSender.GetList("Rating");
        }

        public async Task<Rating> GetBySlug(string slug)
        {
            return await _requestSender.GetDetail("Rating", slug);
        }

        public async Task<Rating> Create(Rating model)
        {
            return await _requestSender.Create("Rating", model);
        }
    }
}
