using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class UpdateCartRequestDto
    {
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
    }
}
