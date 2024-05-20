using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Variant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public uint Stock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
