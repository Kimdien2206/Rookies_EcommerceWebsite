using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Rating
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Range(0, 5)]
        public float Rate { get; set; }
        public string Content { get; set; }
        [MaxLength(100)]
        public string ProductId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; } = null!;
    }
}
