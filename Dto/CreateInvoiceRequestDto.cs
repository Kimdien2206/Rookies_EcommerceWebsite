using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateInvoiceRequestDto
    {
        public ICollection<InvoiceVariantDto> InvoiceVariants { get; set; }
        public ulong TotalCost { get; set; }
    }
}
