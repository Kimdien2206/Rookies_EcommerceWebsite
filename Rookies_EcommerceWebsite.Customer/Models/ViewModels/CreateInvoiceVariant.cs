namespace Rookies_EcommerceWebsite.Customer.Models.ViewModels
{
    public class CreateInvoiceVariant
    {
        public string VariantID { get; set; }
        public ushort Amount { get; set; }
        public string CartId { get; set; }
    }
}
