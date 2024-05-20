using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Product> Products { get;} = new List<Product>();
    }
}
