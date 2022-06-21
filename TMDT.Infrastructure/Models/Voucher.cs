using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string VoucherNo { get; set; }
        public string VoucherName { get; set; }
        public double? SalePercent { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
