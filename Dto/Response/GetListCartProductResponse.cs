using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Response
{
    public class GetListCartProductResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string Slug { get; set; }
        public ulong Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //public ICollection<Rating> Ratings { get; set; }
        public string CategoryId { get; set; }
    }
}
