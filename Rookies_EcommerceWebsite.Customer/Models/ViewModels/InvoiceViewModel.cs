using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models.ViewModels
{
    public class InvoiceViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public List<CreateInvoiceVariant> invoiceVariants {  get; set; } = new List<CreateInvoiceVariant>();
    }
}
