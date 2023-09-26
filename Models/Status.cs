using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Status
    {
        public Status()
        {
            Bronchures = new HashSet<Bronchure>();
            Cards = new HashSet<Card>();
            Flyers = new HashSet<Flyer>();
            Postcards = new HashSet<Postcard>();
            Shirts = new HashSet<Shirt>();
        }

        public int PkStatus { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Bronchure> Bronchures { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Flyer> Flyers { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
