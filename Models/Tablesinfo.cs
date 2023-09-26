using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.Models
{
    public partial class Tablesinfo
    {
        public int PkTablesInfo { get; set; }
        public string? TableName { get; set; }
        public string? Columns { get; set; }
    }
}
