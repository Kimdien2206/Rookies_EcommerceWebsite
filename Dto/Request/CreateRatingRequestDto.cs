using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateRatingRequestDto
    {
        public float Rate { get; set; }
        public string Content { get; set; }
        public string ProductId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
