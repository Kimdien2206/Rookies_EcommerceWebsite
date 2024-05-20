using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Rating
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public float Rate { get; set; }
        public string Content { get; set; }
        public string ProductId { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
