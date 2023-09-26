using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class ContactInfo
    {
        public int PkContactInfo { get; set; }
        public string? Name { get; set; }
        public string? BusinessName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
