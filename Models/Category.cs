using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Category
    {
        public Category()
        {
            Shirts = new HashSet<Shirt>();
        }

        public int PkCategory { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
