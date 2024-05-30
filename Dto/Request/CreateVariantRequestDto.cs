using Dtos.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class CreateVariantRequestDto
    {
        IEnumerable<CreateVariantDto> Variants {  get; set; }
    }
}
