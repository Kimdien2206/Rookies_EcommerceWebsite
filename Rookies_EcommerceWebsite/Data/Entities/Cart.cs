using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Variant Variant { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        public User Owner { get; set; }
    }
}
