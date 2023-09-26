using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Product
    {
        public int PkProducts { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
