using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Customer
    {
        public Customer()
        {
            MembershipCards = new HashSet<MembershipCard>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<MembershipCard> MembershipCards { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
