using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class SerialProImage
    {
        public string SerialNo { get; set; }
        public string SerialImageNo { get; set; }
        public string ProductImageUrl { get; set; }

        public virtual SerialProduct SerialNoNavigation { get; set; }
    }
}
