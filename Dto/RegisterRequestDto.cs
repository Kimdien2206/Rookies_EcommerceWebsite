﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
