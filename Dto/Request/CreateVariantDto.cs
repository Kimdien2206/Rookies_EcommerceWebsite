using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Request
{
    public class CreateVariantDto
    {
        public string Name { get; set; }
        public uint Stock { get; set; }
    }
}
