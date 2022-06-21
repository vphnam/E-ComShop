using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        public string TypeNo { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
