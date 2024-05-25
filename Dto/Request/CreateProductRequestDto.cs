using Dtos.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string Slug { get; set; }
        public ulong? Price { get; set; }
        public ICollection<CreateVariantDto> Variants { get; set; }
        public string CategoryId { get; set; }
    }
}
