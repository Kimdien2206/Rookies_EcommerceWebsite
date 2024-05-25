﻿using Rookies_EcommerceWebsite.Customer.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookies_EcommerceWebsite.Customer.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual ICollection<InvoiceVariant> InvoiceVariants { get; set; } = new List<InvoiceVariant>();
        public ulong TotalCost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
    }
}