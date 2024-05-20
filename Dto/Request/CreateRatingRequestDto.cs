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
        public string AuthorId { get; set; }
    }
}
