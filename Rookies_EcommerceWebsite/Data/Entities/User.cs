﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } 
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; } = new DateOnly(1950, 1, 1);
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenValidity { get; set; }
        public IdentityRole? Role { get; set; }
    }
}
