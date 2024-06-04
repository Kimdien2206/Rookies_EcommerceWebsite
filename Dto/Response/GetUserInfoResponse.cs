using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Response
{
    public class GetUserInfoResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenValidity { get; set; }
    }
}
