using Microsoft.AspNetCore.Identity;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } 
        
        public DateOnly DateOfBirth { get; set; } 
    }
}
