using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class InvoiceVariantDto
    {
        public string VariantId { get; set; }
        public ushort Amount { get; set; }
        public string CartId { get; set; }
    }
}
