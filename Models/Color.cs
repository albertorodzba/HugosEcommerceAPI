using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Color
    {
        public Color()
        {
            Bronchures = new HashSet<Bronchure>();
            Cards = new HashSet<Card>();
            Flyers = new HashSet<Flyer>();
            Postcards = new HashSet<Postcard>();
            Shirts = new HashSet<Shirt>();
        }

        public int PkColor { get; set; }
        public string ColorName { get; set; } = null!;

        public virtual ICollection<Bronchure> Bronchures { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Flyer> Flyers { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
        public virtual ICollection<Shirt> Shirts { get; set; }
    }
}
