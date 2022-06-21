using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Color
    {
        public Color()
        {
            SerialProducts = new HashSet<SerialProduct>();
        }

        public string ColorNo { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<SerialProduct> SerialProducts { get; set; }
    }
}
