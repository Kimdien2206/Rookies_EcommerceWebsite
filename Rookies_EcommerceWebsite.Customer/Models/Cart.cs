using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Cart
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? VariantId { get; set; } = null!;
        public Variant Variant { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        public string? CustomerId { get; set; } = null!;
        public UserInfo Customer { get; set; }
    }
}
