﻿using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Material
    {
        public Material()
        {
            Bronchures = new HashSet<Bronchure>();
            Cards = new HashSet<Card>();
            Flyers = new HashSet<Flyer>();
            Postcards = new HashSet<Postcard>();
        }

        public int PkMaterial { get; set; }
        public string? MaterialName { get; set; }

        public virtual ICollection<Bronchure> Bronchures { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Flyer> Flyers { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
    }
}
