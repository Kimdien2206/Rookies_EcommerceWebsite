using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class InvoiceVariant
    {
        public string InvoiceID { get; set; }
        public string VariantID { get; set; }
        public Variant Variant { get; set; }
        public ulong Price { get; set; }
        public ushort Amount { get; set; }
        public ulong TotalCost { get; set; }
    }
}
