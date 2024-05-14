using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
