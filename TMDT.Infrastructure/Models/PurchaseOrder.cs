using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Feedbacks = new HashSet<Feedback>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }

        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerNo { get; set; }
        public string EmployeeNo { get; set; }
        public string VoucherNo { get; set; }
        public string Note { get; set; }
        public bool SentMail { get; set; }
        public int ProcessStatus { get; set; }
        public bool Status { get; set; }

        public virtual Customer CustomerNoNavigation { get; set; }
        public virtual Employee EmployeeNoNavigation { get; set; }
        public virtual Voucher VoucherNoNavigation { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
