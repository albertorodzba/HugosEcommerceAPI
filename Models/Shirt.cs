using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Shirt
    {
        public int PkShirt { get; set; }
        public int? FkBrand { get; set; }
        public int? FkSize { get; set; }
        public int? FkFabric { get; set; }
        public int? FkColor { get; set; }
        public int? FkCategory { get; set; }
        public int? FkStyle { get; set; }
        public int? FkProcess { get; set; }
        public string? Description { get; set; }
        public float Cost { get; set; }
        public string? ImageLocation { get; set; }
        public int? ProductStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Brand? FkBrandNavigation { get; set; }
        public virtual Category? FkCategoryNavigation { get; set; }
        public virtual Color? FkColorNavigation { get; set; }
        public virtual Fabric? FkFabricNavigation { get; set; }
        public virtual Process? FkProcessNavigation { get; set; }
        public virtual Size? FkSizeNavigation { get; set; }
        public virtual Style? FkStyleNavigation { get; set; }
        public virtual Status? ProductStatusNavigation { get; set; }
    }
}
