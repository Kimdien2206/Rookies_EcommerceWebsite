using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
