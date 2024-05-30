namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class VnPayLinkRequestModel
    {
        public ulong Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string InvoiceId { get; set; }
    }
}
