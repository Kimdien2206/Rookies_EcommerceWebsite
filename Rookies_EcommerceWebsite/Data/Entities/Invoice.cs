using Rookies_EcommerceWebsite.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual ICollection<InvoiceVariant> InvoiceVariants { get; set; } = new List<InvoiceVariant>();
        public ulong TotalCost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
    }
}
