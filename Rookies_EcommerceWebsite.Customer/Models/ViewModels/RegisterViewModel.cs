using System.ComponentModel.DataAnnotations;

namespace Rookies_EcommerceWebsite.Customer.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(10)]
        [MinLength(10, ErrorMessage = "Phone number must contain 10 digits")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Incorrect phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
