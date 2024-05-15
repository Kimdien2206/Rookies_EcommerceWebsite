using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class InvoiceVariantDto
    {
        public string InvoiceID { get; set; }
        public string VariantID { get; set; }
        public ulong Price { get; set; }
        public ushort Amount { get; set; }
        public ulong TotalCost { get; set; }
    }
}
