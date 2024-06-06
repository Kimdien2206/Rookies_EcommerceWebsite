using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class LoggedInResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Roles { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenValidity { get; set; }
    }
}
