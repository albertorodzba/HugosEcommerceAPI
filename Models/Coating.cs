using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Coating
    {
        public Coating()
        {
            Bronchures = new HashSet<Bronchure>();
            Cards = new HashSet<Card>();
            Flyers = new HashSet<Flyer>();
            Postcards = new HashSet<Postcard>();
        }

        public int PkCoating { get; set; }
        public string? CoatingName { get; set; }

        public virtual ICollection<Bronchure> Bronchures { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Flyer> Flyers { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
    }
}
