using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateCartRequestDto
    {
        public string VariantId { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        public string CustomerId { get; set; }

    }
}
