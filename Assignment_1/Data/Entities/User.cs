using Microsoft.AspNetCore.Identity;

namespace Assignment_1.Data.Entities
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } 
        
        public DateOnly DateOfBirth { get; set; } 
    }
}
