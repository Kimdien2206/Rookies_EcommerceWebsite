﻿namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong? Price { get; set; }

    }
}
