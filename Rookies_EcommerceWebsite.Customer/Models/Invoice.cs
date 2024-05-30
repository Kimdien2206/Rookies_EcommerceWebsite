using Rookies_EcommerceWebsite.Customer.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Invoice
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ulong TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public virtual ICollection<InvoiceVariant> InvoiceVariants { get; set; } = new List<InvoiceVariant>();
    }
}
