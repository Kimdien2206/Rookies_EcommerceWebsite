using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Response
{
    public class GetListCartResponse
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string VariantId { get; set; }
        public GetListCartVariantResponse Variant { get; set; }
        public uint Amount { get; set; }
        public ulong TotalCost { get; set; }
        public string CustomerId { get; set; }
    }
}
