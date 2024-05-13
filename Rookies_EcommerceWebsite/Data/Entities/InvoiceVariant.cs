using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    [PrimaryKey("InvoiceID", ["VariantID"])]
    public class InvoiceVariant
    {
        public Guid InvoiceID { get; set; }
        public Guid VariantID { get; set; }
        public Invoice Invoice { get; set; }
        public Variant Variant { get; set; }
        public ulong Price { get; set; }
        public ushort Amount { get; set; }
        public ulong TotalCost { get; set; }
    }
}
