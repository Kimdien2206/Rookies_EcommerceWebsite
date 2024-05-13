using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class RegisterSuccessResponseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
