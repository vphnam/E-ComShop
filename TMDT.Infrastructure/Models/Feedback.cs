using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Feedback
    {
        public long FeedbackNo { get; set; }
        public int? OrderNo { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }

        public virtual PurchaseOrder OrderNoNavigation { get; set; }
    }
}
