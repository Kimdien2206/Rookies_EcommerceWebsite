﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class VnPayPaymentRequestDto
    {

        public uint Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string InvoiceId { get; set; }
    }
}
