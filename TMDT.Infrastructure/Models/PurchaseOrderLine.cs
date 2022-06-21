using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class PurchaseOrderLine
    {
        public int OrderNo { get; set; }
        public string SerialNo { get; set; }
        public int? QuantityOrdered { get; set; }
        public decimal? BuyPrice { get; set; }

        public virtual PurchaseOrder OrderNoNavigation { get; set; }
        public virtual SerialProduct SerialNoNavigation { get; set; }
    }
}
