using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Fabric
    {
        public Fabric()
        {
            Shirts = new HashSet<Shirt>();
        }

        public int PkFabric { get; set; }
        public string FabricName { get; set; } = null!;

        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
