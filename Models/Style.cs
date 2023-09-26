using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Style
    {
        public Style()
        {
            Shirts = new HashSet<Shirt>();
        }

        public int PkStyle { get; set; }
        public string SytleName { get; set; } = null!;

        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
