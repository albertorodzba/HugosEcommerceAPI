using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int PkRole { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
