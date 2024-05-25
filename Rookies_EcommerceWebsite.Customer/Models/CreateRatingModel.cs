namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class CreateRatingModel
    {
        public float Rate { get; set; }
        public string Content { get; set; }
        public string ProductId { get; set; }
        public string AuthorId { get; set; }
    }
}
