using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Request
{
    public class UpdateUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
