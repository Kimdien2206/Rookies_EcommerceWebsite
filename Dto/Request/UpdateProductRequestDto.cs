using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class UpdateProductRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string Slug { get; set; }
        public ulong? Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
