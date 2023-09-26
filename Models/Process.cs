using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Process
    {
        public Process()
        {
            Shirts = new HashSet<Shirt>();
        }

        public int PkProcess { get; set; }
        public string ProcessName { get; set; } = null!;

        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
