using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateInvoiceRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<InvoiceVariantDto> InvoiceVariants { get; set; }
    }
}
