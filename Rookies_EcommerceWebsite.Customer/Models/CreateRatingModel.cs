using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class CreateRatingModel
    {
        [Required]
        public float Rate { get; set; }
        public string? Content { get; set; }

        [Required]
        public string ProductId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Email { get; set; } = null!;
        [Required]
        public string RedirectSlug { get; set; }
    }
}
