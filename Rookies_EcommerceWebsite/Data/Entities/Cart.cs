using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(100)]
        [AllowNull]
        public string? VariantId { get; set; } = null!;
        public Variant Variant { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        [MaxLength(450)]
        [AllowNull]
        public string? CustomerId { get; set; } = null!;
        public User Customer { get; set; }
    }
}
