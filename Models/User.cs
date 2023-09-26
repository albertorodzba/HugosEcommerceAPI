using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class User
    {
        public long PkUser { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Role? RoleNavigation { get; set; }
    }
}
