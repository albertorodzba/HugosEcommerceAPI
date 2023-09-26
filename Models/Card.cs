using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Card
    {
        public int PkCard { get; set; }
        public int? FkSize { get; set; }
        public int? FkMaterial { get; set; }
        public int? FkColor { get; set; }
        public int? FkCoating { get; set; }
        public int? FkRunsize { get; set; }
        public string? Description { get; set; }
        public float Cost { get; set; }
        public string? ImageLocation { get; set; }
        public int? ProductStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Coating? FkCoatingNavigation { get; set; }
        public virtual Color? FkColorNavigation { get; set; }
        public virtual Material? FkMaterialNavigation { get; set; }
        public virtual Runsize? FkRunsizeNavigation { get; set; }
        public virtual Size? FkSizeNavigation { get; set; }
        public virtual Status? ProductStatusNavigation { get; set; }
    }
}
