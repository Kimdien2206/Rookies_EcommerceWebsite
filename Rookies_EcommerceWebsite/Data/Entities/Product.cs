using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string Slug { get; set; }
        public ulong? Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public ICollection<Variant> Variants { get; set; } = null!;
        public ICollection<Rating> Ratings { get; set; } = null!;
        public string CategoryId { get; set; }
        //public Category Category { get; set; } = null!;
    }
}
