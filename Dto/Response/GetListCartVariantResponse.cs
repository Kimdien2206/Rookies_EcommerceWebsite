using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Response
{
    public class GetListCartVariantResponse
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public uint Stock { get; set; }
        public string ProductId { get; set; }
        public GetListCartProductResponse Product { get; set; }
    }
}
