using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Variant Variant { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        public User Customer { get; set; }
    }
}
