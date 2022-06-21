using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Style
    {
        public Style()
        {
            Products = new HashSet<Product>();
        }

        public string StyleNo { get; set; }
        public string StyleName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
