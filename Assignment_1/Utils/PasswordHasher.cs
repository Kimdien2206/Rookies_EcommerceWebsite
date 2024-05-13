using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Assignment_1.Utils
{
    public class PasswordHasher : IPasswordHasher<IdentityUser>
    {
        //private readonly int _saltSize;
        //private readonly int _bytesRequired;
        //private readonly int _iterations;
        //public PasswordHasher()
        //{
        //    this._saltSize = 128 / 8;
        //    this._bytesRequired = 32;
        //    this._iterations = 1000;
        //}


        public string HashPassword(IdentityUser user, string password)
        {
            //string mySalt = BCrypt.GenerateSalt();
            ////mySalt == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO"
            //string myHash = BCrypt.HashPassword(myPassword, mySalt);
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(IdentityUser user, string hashedPassword, string providedPassword)
        {
            //// Throw an error if any of our passwords are null
            //ThrowIf.ArgumentIsNull(() => hashedPassword, () => providedPassword);

            //// Get our decoded hash
            //var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            //// If our password length is 0, return an error
            //if (decodedHashedPassword.Length == 0)
            //    return PasswordVerificationResult.Failed;

            //var t = decodedHashedPassword[0];

            //// Do a switch
            //switch (decodedHashedPassword[0])
            //{
            //    case 0x00:
            //        return PasswordVerificationResult.Success;

            //    default:
            //        return PasswordVerificationResult.Failed;
            //}
            throw new NotImplementedException();
        }
    }
}
