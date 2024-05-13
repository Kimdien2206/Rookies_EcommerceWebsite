using Microsoft.AspNetCore.Identity;

namespace Assignment_1.Utils
{
    public class PasswordHasher : IPasswordHasher<IdentityUser>
    {
        public string HashPassword(IdentityUser user, string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(IdentityUser user, string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
