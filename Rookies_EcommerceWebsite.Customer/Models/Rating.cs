using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Rating
    {

        public string? Id { get; set; }
        public float Rate { get; set; }
        public string? Content { get; set; }
        public string ProductId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; } = null!;
    }
}
