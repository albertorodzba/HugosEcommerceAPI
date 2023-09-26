using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Shirts = new HashSet<Shirt>();
        }

        public int PkBrand { get; set; }
        public string BrandName { get; set; } = null!;
        public string? Sku { get; set; }

        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
