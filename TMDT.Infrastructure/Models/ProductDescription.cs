using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class ProductDescription
    {
        public string ProductDescNo { get; set; }
        public string ProductNo { get; set; }
        public string ProductDescImage { get; set; }
        public string ProductDescription1 { get; set; }

        public virtual Product ProductNoNavigation { get; set; }
    }
}
