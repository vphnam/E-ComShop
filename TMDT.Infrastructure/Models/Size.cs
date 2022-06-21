using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Size
    {
        public Size()
        {
            SerialProducts = new HashSet<SerialProduct>();
        }

        public string SizeNo { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<SerialProduct> SerialProducts { get; set; }
    }
}
